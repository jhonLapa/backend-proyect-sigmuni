using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class SeccionDocumentalRepository : ISeccionDocumentalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<SeccionDocumental> _paginator;

        public SeccionDocumentalRepository(ApplicationDbContext context, IPaginator<SeccionDocumental> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<SeccionDocumental> Create(SeccionDocumental entity)
        {
            _context.SeccionDocumentales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<SeccionDocumental?> Edit(int id, SeccionDocumental entity)
        {
            var model = await _context.SeccionDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Codigo = entity.Codigo;
                model.Siglas = entity.Siglas;

                _context.SeccionDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SeccionDocumental?> Disable(int id)
        {
            var model = await _context.SeccionDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.SeccionDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SeccionDocumental?> Find(int id)
        => await _context.SeccionDocumentales.FindAsync(id);

        public async Task<IList<SeccionDocumental>> FindAll()
       => await _context.SeccionDocumentales
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.Id)
           .ToListAsync();

        public async Task<ResponsePagination<SeccionDocumental>> PaginatedSearch(RequestPagination<SeccionDocumental> entity)
        {

            var filter = entity.Filter;
            var query = _context.SeccionDocumentales.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
