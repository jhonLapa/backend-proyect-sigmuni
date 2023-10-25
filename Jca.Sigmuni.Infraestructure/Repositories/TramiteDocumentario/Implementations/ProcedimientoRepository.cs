using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class ProcedimientoRepository : IProcedimientoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Procedimiento> _paginator;

        public ProcedimientoRepository(ApplicationDbContext context, IPaginator<Procedimiento> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Procedimiento> Create(Procedimiento entity)
        {
            var entidad = await _context.Procedimientos.FindAsync(entity.Id);
            if (entidad == null)
            {
                entidad = new Procedimiento();
            }
            entidad.AsuntoTramite = entity.AsuntoTramite;
            entidad.Descripcion = entity.Descripcion;
            entidad.IdUsuario = entity.IdUsuario;
            entidad.IdTipoTramite = entity.TipoTramite.IdTipoTramite;
            entidad.Normativa = entity.Normativa;
            entidad.Codigo = entity.Codigo;

            if (entity.Id == 0)
            {
                entidad.RequiereCuc = 0;
                _context.Procedimientos.Add(entidad);
            }

            await _context.SaveChangesAsync();
            return entidad;
        }

        public async Task<Procedimiento?> Disable(int id)
        {
            var model = await _context.Procedimientos.FindAsync(id);
            if (model != null)
            {
                model.Estado = false;
                _context.Procedimientos.Update(model);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<Procedimiento?> Edit(int id, Procedimiento entity)
        {
            var model = await _context.Procedimientos.FindAsync(id);
            if(model!=null)
            {
                model.AsuntoTramite = entity.AsuntoTramite;
                model.Descripcion = entity.Descripcion;
                model.IdUsuario = entity.IdUsuario;
                model.IdTipoTramite = entity.TipoTramite.IdTipoTramite;
                model.Normativa = entity.Normativa;
                model.Codigo = entity.Codigo;

                _context.Procedimientos.Update(model);
                await _context.SaveChangesAsync();
            }
            return model;
        }

        public async Task<Procedimiento?> Find(int id)
        => await _context.Procedimientos.Include(x => x.TipoTramite)
            .Include(x=>x.Actividad)
            .Include(x => x.Actividad).ThenInclude(x=>x.AccionGenerar)
            .Include(x => x.Actividad).ThenInclude(x => x.Area)
            .Include(x => x.Actividad).ThenInclude(x => x.TipoActividad)
            .Include(x => x.Actividad).ThenInclude(x => x.Resultado)
            .Include(x => x.Actividad).ThenInclude(x => x.ResultadoII)
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IList<Procedimiento>> FindTramite(int idTipoTramite)
       => await _context.Procedimientos.Include(x => x.TipoTramite).
            Where(d => d.IdTipoTramite.Equals(idTipoTramite)).Where(e => e.Estado == true).AsNoTracking().ToListAsync();

        public async Task<IList<Procedimiento>> FindAll()
        => await _context.Procedimientos
            .Include(x => x.Usuario)
            .Include(x => x.TipoTramite)
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();


        public async Task<ResponsePagination<Procedimiento>> PaginatedSearch(RequestPagination<Procedimiento> entity)
        {
            var filter =entity.Filter;
            var query = _context.Procedimientos
                .Include(x => x.TipoTramite)
                .Include(x => x.Usuario)
                .AsQueryable();
            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdUsuario.HasValue|| e.IdUsuario==filter.IdUsuario)
                    &&(!filter.IdTipoTramite.HasValue||e.IdTipoTramite==filter.IdTipoTramite)
                    && (string.IsNullOrWhiteSpace(filter.AsuntoTramite)||e.AsuntoTramite.ToUpper().Contains(filter.AsuntoTramite))
                    && (string.IsNullOrWhiteSpace(filter.Codigo)||e.Codigo.ToUpper().Contains(filter.Codigo))
                    //&&(string.IsNullOrWhiteSpace(filter.FechaRegistroDesde.ToString())||e.FechaRegistro >= filter.FechaRegistroDesde )
                    //&& (string.IsNullOrWhiteSpace(filter.FechaRegistroHasta.ToString()) || e.FechaRegistro <= filter.FechaRegistroHasta)
                );
            }
            query = query.OrderByDescending(e => e.Id);
            var response = await _paginator.Paginate(query, entity);
            return response;
        }

        public async Task<Procedimiento> ObtenerUltimoProcedimiento()
        {
            string sqlQuery = "SELECT * from trd.generar_numero_procedimiento()";
            Procedimiento data=new Procedimiento();
            using DbConnection dbConnection = _context.Database.GetDbConnection();

            using DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            await dbConnection.OpenAsync();
            using IDataReader reader = await dbCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                data.Codigo= !reader.IsDBNull(reader.GetOrdinal("numero_correlativo")) ? reader.GetString(reader.GetOrdinal("numero_correlativo")) : null;
            }
            reader.Close();

            return data;

        }

        public async Task<ResponsePagination<Procedimiento>> PaginatedSearchFiltros(RequestPagination<Procedimiento> entity, string? fechaRegistroDesde, string? fechaRegistroHasta)
        {
            var filter = entity.Filter;
            var query = _context.Procedimientos
                .Include(x => x.TipoTramite)
                .Include(x => x.Usuario)
                .AsQueryable();
            if (filter != null)
            {
                query = query
                    .Where(e =>(!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.AsuntoTramite) || e.AsuntoTramite.ToUpper().Contains(filter.AsuntoTramite))
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper()))
                    && (string.IsNullOrWhiteSpace(fechaRegistroDesde) || e.FechaRegistro >= Convert.ToDateTime(fechaRegistroDesde))
                    && (string.IsNullOrWhiteSpace(fechaRegistroHasta) || e.FechaRegistro <= Convert.ToDateTime(fechaRegistroHasta).AddDays(1))
                    && (!filter.IdUsuario.HasValue || e.IdUsuario == filter.IdUsuario)
                    && (!filter.IdTipoTramite.HasValue || e.IdTipoTramite == filter.IdTipoTramite)
                );
            }
            query = query.OrderByDescending(e => e.Id);
            var response = await _paginator.Paginate(query, entity);
            return response;
        }


    }
}
