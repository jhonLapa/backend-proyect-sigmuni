using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class InfDocumentoSPRepository : IInfDocumentoSPRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<InfDocumento> _paginator;

        public InfDocumentoSPRepository(ApplicationDbContext context, IPaginator<InfDocumento> paginator)
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
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.Id.Equals(id));

        public async Task<InfDocumento?> ListarDetalleAsync(string numExpendiente, string anioExpediente)
        => await _context.InfDocumentos
            .Include(x => x.TipoDocumental)
            .Include(x => x.SerieDocumental)
            .Include(x => x.SubSerieDocumental)
            .Include(x => x.SeccionDocumental)
            .Include(x => x.Solicitud)
            .DefaultIfEmpty()
            .FirstOrDefaultAsync(e => e.Solicitud.NumeroExpediente == numExpendiente && e.Anio == anioExpediente);

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
               //.Include(x => x.TramiteDocumento)
               //.Include(x => x.TramiteDocumento).ThenInclude(t=>t.TipoPrestamo)
               //.Include(x => x.TramiteDocumento).ThenInclude(t => t.persona)
               .Include(x => x.Solicitud)
               //.Include(x => x.Solicitud).ThenInclude(t=>t.SolicitudCuc)
               .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.NumRegistro) || e.NumRegistro.ToUpper().Contains(filter.NumRegistro.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.RazonSocial) || e.RazonSocial.ToUpper().Contains(filter.RazonSocial.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
