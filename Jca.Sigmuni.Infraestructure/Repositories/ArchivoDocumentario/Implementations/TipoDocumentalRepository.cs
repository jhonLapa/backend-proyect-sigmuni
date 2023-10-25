using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class TipoDocumentalRepository : ITipoDocumentalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoDocumental> _paginator;

        public TipoDocumentalRepository(ApplicationDbContext context, IPaginator<TipoDocumental> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<TipoDocumental> Create(TipoDocumental entity)
        {
            _context.TipoDocumentales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<TipoDocumental?> Edit(int id, TipoDocumental entity)
        {
            var model = await _context.TipoDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Codigo = entity.Codigo;
                model.Siglas = entity.Siglas;

                _context.TipoDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<TipoDocumental?> Disable(int id)
        {
            var model = await _context.TipoDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.TipoDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<TipoDocumental?> Find(int id)
        => await _context.TipoDocumentales.FindAsync(id);

        public async Task<IList<TipoDocumental>> FindAll()
        => await _context.TipoDocumentales
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<TipoDocumental>> PaginatedSearch(RequestPagination<TipoDocumental> entity)
        {

            var filter = entity.Filter;
            var query = _context.TipoDocumentales.AsQueryable();

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
