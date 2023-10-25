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
    public class InfDocumentoRepository : IInfDocumentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<InfDocumento> _paginator;

        public InfDocumentoRepository(ApplicationDbContext context, IPaginator<InfDocumento> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<InfDocumento> Create(InfDocumento entity)
        {
            _context.InfDocumentos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<InfDocumento?> Edit(int id, InfDocumento entity)
        {
            var model = await _context.InfDocumentos.FindAsync(id);

            if (model != null)
            {
                model.NumRegistro = entity.NumRegistro;
                model.FechaInicio = entity.FechaInicio;

                model.RazonSocial = entity.RazonSocial;
                model.Asunto = entity.Asunto;
                model.InformacionRelevante = entity.InformacionRelevante;
                model.NumFolios = entity.NumFolios;
                model.TotalImagenes = entity.TotalImagenes;
                model.Mayora3 = entity.Mayora3;
                model.TapaContratapa = entity.TapaContratapa;
                model.NumUnidadCaja = entity.NumUnidadCaja;
                model.Anio = entity.Anio;
                model.Observaciones = entity.Observaciones;
                model.NumModulo = entity.NumModulo;
                model.Lado = entity.Lado;
                model.NumCuerpo = entity.NumCuerpo;
                model.NumBalda = entity.NumBalda;
                model.NumConcatRegistro = entity.NumConcatRegistro;
                model.IdSolicitud = entity.IdSolicitud;


                _context.InfDocumentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<InfDocumento?> Disable(int id)
        {
            var model = await _context.InfDocumentos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.InfDocumentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<InfDocumento?> Find(int id)
       => await _context.InfDocumentos
            .Include(x => x.TipoDocumental)
            .Include(x => x.SerieDocumental)
            .Include(x => x.SubSerieDocumental)
            .Include(x => x.SeccionDocumental)
            .Include(x => x.Solicitud).ThenInclude(x => x.Solicitante)
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<InfDocumento?> BuscarXsolicitud(int id)
        => await _context.InfDocumentos
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.IdSolicitud.Equals(id));

        public async Task<IList<InfDocumento>> FindAll()
       => await _context.InfDocumentos
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.Id)
           .ToListAsync();
        public async Task<ResponsePagination<InfDocumento>> PaginatedSearch(RequestPagination<InfDocumento> entity)
        {

            var filter = entity.Filter;
            //var query = _context.InfDocumentos.AsQueryable();

            var query = _context.InfDocumentos
               .Include(x => x.TipoDocumental)
               .Include(x => x.SerieDocumental)
               .Include(x => x.SubSerieDocumental)
               .Include(x => x.SeccionDocumental)
               .Include(x => x.Solicitud)
               .AsQueryable();

            if (filter != null)
            {
                if (filter.IdTipoDocumental == 0)
                {
                    filter.IdTipoDocumental = null;
                }
                if (filter.IdSerieDocumental == 0)
                {
                    filter.IdSerieDocumental = null;
                }
                if (filter.IdSubSerieDoc == 0)
                {
                    filter.IdSubSerieDoc = null;
                }
                if (filter.IdSolicitud == 0)
                {
                    filter.IdSolicitud = null;
                }

                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (!filter.IdTipoDocumental.HasValue || e.IdTipoDocumental == filter.IdTipoDocumental)
                    && (!filter.IdSerieDocumental.HasValue || e.IdSerieDocumental == filter.IdSerieDocumental)
                    && (!filter.IdSubSerieDoc.HasValue || e.IdSubSerieDoc == filter.IdSubSerieDoc)
                    && (!filter.IdSolicitud.HasValue || e.IdSolicitud == filter.IdSolicitud)
                    && (string.IsNullOrWhiteSpace(filter.NumConcatRegistro) || e.NumConcatRegistro.ToUpper().Contains(filter.NumConcatRegistro.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Anio) || e.Anio.ToUpper().Contains(filter.Anio.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Asunto) || e.Asunto.ToUpper().Contains(filter.Asunto.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.RazonSocial) || e.RazonSocial.ToUpper().Contains(filter.RazonSocial.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.InformacionRelevante) || e.InformacionRelevante.ToUpper().Contains(filter.InformacionRelevante.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.NumUnidadCaja) || e.NumUnidadCaja.ToUpper().Contains(filter.NumUnidadCaja.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }



        public async Task<InfDocumento> ObtenerUltimoNumeroInf()
        {
            string sqlQuery = "SELECT * from doc.generar_numero_inf_documento()";
            InfDocumento data = new InfDocumento();
            using DbConnection dbConnection = _context.Database.GetDbConnection();

            using DbCommand dbCommand = dbConnection.CreateCommand();
            dbCommand.CommandText = sqlQuery;
            await dbConnection.OpenAsync();
            using IDataReader reader = await dbCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                data.NumRegistro = !reader.IsDBNull(reader.GetOrdinal("numero_correlativo")) ? reader.GetString(reader.GetOrdinal("numero_correlativo")) : null;
                data.Anio = !reader.IsDBNull(reader.GetOrdinal("anio")) ? reader.GetString(reader.GetOrdinal("anio")) : null;

            }
            reader.Close();

            return data;

        }
    }
}
