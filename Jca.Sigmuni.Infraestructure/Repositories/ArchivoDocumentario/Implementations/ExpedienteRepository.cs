using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class ExpedienteRepository : IExpedienteRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Expediente> _paginator;

        public ExpedienteRepository(ApplicationDbContext context, IPaginator<Expediente> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<Expediente> Create(Expediente entity)
        {
            _context.Expedientes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Expediente?> Edit(int id, Expediente entity)
        {
            var model = await _context.Expedientes.FindAsync(id);

            if (model != null)
            {
                model.IdDocumento = entity.IdDocumento;
                model.Folios = entity.Folios;
                model.Estado = entity.Estado;


                _context.Expedientes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Expediente?> Disable(int id)
        {
            var model = await _context.Expedientes.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Expedientes.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Expediente?> Find(int id)
        => await _context.Expedientes.FindAsync(id);
        public async Task<IList<Expediente>> FindAll()
        => await _context.Expedientes
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();
        public async Task<ResponsePagination<Expediente>> PaginatedSearch(RequestPagination<Expediente> entity)
        {

            var filter = entity.Filter;
            var query = _context.Expedientes.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
        public async Task<List<Expediente>> FindxInfo(int id)
            => await _context.Expedientes
            .Include(x => x.InfDocumento)
            .Include(x => x.Documento)
            .Where(e => e.Estado == true && e.IdInfDocumento == id)
            .OrderByDescending(e => e.IdInfDocumento)
            .ToListAsync();

        public async Task<Expediente> FindxInforme(int id)
        => await _context.Expedientes.Include(x => x.InfDocumento)
            .Include(x => x.Documento)
            .Where(e => e.Estado == true && e.IdInfDocumento == id).FirstOrDefaultAsync();
    }
}
