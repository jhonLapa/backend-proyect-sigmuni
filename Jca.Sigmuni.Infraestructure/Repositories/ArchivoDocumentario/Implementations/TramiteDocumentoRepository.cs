using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class TramiteDocumentoRepository : ITramiteDocumentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TramiteDocumento> _paginator;

        public TramiteDocumentoRepository(ApplicationDbContext context, IPaginator<TramiteDocumento> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<TramiteDocumento> Create(TramiteDocumento entity)
        {
            _context.TramiteDocumentos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TramiteDocumento?> Edit(int id, TramiteDocumento entity)
        {
            var model = await _context.TramiteDocumentos.FindAsync(id);

            if (model != null)
            {
                model.Numero = entity.Numero;
                model.Anio = entity.Anio;
                model.IdSolicitante = entity.IdSolicitante;
                model.FlagDevuelto = entity.FlagDevuelto;
                model.FoliosPrestados = entity.FoliosPrestados;


                _context.TramiteDocumentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<TramiteDocumento?> Disable(int id)
        {
            var model = await _context.TramiteDocumentos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.TramiteDocumentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TramiteDocumento?> Find(int id)
      => await _context.TramiteDocumentos
           .Include(x => x.InfDocumento)
           .Include(x => x.InfDocumento).ThenInclude(t => t.Solicitud)
           .Include(x => x.TipoPrestamo)
           .Include(x => x.Persona)
           .Include(x => x.Persona).ThenInclude(t => t.InfoContacto)
           .Include(x => x.Persona).ThenInclude(t => t.TipoPersona)
           .Include(x => x.Persona).ThenInclude(t => t.DocumentoIdentidad)
           .Include(x => x.Persona).ThenInclude(t => t.Usuario)
           .DefaultIfEmpty()
           .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<IList<TramiteDocumento>> FindXNumeroAnio(string Numero, string Anio)
      => await _context.TramiteDocumentos
           .Include(x => x.InfDocumento)
           .Include(x => x.InfDocumento).ThenInclude(t => t.Solicitud)
           .Include(x => x.InfDocumento).ThenInclude(t => t.SeccionDocumental)
           .Include(x => x.InfDocumento).ThenInclude(t => t.SerieDocumental)
           .Include(x => x.InfDocumento).ThenInclude(t => t.SubSerieDocumental)
           .Include(x => x.InfDocumento).ThenInclude(t => t.TipoDocumental)
           .Include(x => x.TipoPrestamo)
           .Include(x => x.Persona)
           .Include(x => x.Persona).ThenInclude(t => t.TipoPersona)
           .Include(x => x.Persona).ThenInclude(t => t.DocumentoIdentidad)
           .Include(x => x.Persona).ThenInclude(t => t.Usuario)
          .Where(e => e.Estado == true && (string.IsNullOrWhiteSpace(Numero) || e.Numero.ToUpper().Contains(Numero.ToUpper().Trim())) && (string.IsNullOrWhiteSpace(Anio) || e.Anio.ToUpper().Contains(Anio.ToUpper().Trim())))
          .OrderByDescending(e => e.Id)
          .ToListAsync();

        //public async Task<TramiteDocumento?> Find(int id)
        //=> await _context.TramiteDocumentos.FindAsync(id);

        public async Task<IList<TramiteDocumento>> FindAll()
        => await _context.TramiteDocumentos
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();
        public async Task<ResponsePagination<TramiteDocumento>> PaginatedSearch(RequestPagination<TramiteDocumento> entity)
        {

            var filter = entity.Filter;
            var query = _context.TramiteDocumentos
                         .Include(x => x.InfDocumento)
                         .Include(x => x.InfDocumento).ThenInclude(t => t.TipoDocumental)
                         .Include(x => x.InfDocumento).ThenInclude(t => t.SerieDocumental)
                         .Include(x => x.InfDocumento).ThenInclude(t => t.SubSerieDocumental)
                         .Include(x => x.InfDocumento).ThenInclude(t => t.SeccionDocumental)
                         .Include(x => x.InfDocumento).ThenInclude(t => t.Solicitud)
                         .Include(x => x.TipoPrestamo)
                         .Include(x => x.Persona)
                        .AsQueryable();

            if (filter != null)
            {
                if (filter.InfDocumento.IdTipoDocumental == 0)
                {
                    filter.InfDocumento.IdTipoDocumental = null;
                }
                if (filter.InfDocumento.IdSerieDocumental == 0)
                {
                    filter.InfDocumento.IdSerieDocumental = null;
                }
                if (filter.InfDocumento.IdSubSerieDoc == 0)
                {
                    filter.InfDocumento.IdSubSerieDoc = null;
                }
                if (filter.InfDocumento.IdSolicitud == 0)
                {
                    filter.InfDocumento.IdSolicitud = null;
                }
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.InfDocumento.IdTipoDocumental.HasValue || e.InfDocumento.IdTipoDocumental == filter.InfDocumento.IdTipoDocumental)
                    && (!filter.InfDocumento.IdSerieDocumental.HasValue || e.InfDocumento.IdSerieDocumental == filter.InfDocumento.IdSerieDocumental)
                    && (!filter.InfDocumento.IdSubSerieDoc.HasValue || e.InfDocumento.IdSubSerieDoc == filter.InfDocumento.IdSubSerieDoc)
                    && (!filter.InfDocumento.IdSolicitud.HasValue || e.InfDocumento.IdSolicitud == filter.InfDocumento.IdSolicitud)
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.NumConcatRegistro) || e.InfDocumento.NumConcatRegistro.ToUpper().Contains(filter.InfDocumento.NumConcatRegistro.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.Anio) || e.InfDocumento.Anio.ToUpper().Contains(filter.InfDocumento.Anio.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.Asunto) || e.InfDocumento.Asunto.ToUpper().Contains(filter.InfDocumento.Asunto.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.RazonSocial) || e.InfDocumento.RazonSocial.ToUpper().Contains(filter.InfDocumento.RazonSocial.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.InformacionRelevante) || e.InfDocumento.InformacionRelevante.ToUpper().Contains(filter.InfDocumento.InformacionRelevante.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InfDocumento.NumUnidadCaja) || e.InfDocumento.NumUnidadCaja.ToUpper().Contains(filter.InfDocumento.NumUnidadCaja.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Numero) || e.Numero.ToUpper().Contains(filter.Numero.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Anio) || e.Anio.ToUpper().Contains(filter.Anio.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

        public async Task<TramiteDocumento> ObtenerUltimoNumeroTramiteDo()
        {
            string sqlQuery = "SELECT * from trd.generar_numero_tramite_documento()";
            TramiteDocumento data = new TramiteDocumento();
            using DbConnection dbConnection = _context.Database.GetDbConnection();

            using DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            await dbConnection.OpenAsync();
            using IDataReader reader = await dbCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                data.Numero = !reader.IsDBNull(reader.GetOrdinal("numero_correlativo")) ? reader.GetString(reader.GetOrdinal("numero_correlativo")) : null;
                data.Anio = !reader.IsDBNull(reader.GetOrdinal("anio")) ? reader.GetString(reader.GetOrdinal("anio")) : null;

            }
            reader.Close();

            return data;

        }
    }
}
