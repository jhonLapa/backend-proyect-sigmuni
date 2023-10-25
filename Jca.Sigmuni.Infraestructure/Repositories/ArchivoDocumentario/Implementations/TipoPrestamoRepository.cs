using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class TipoPrestamoRepository : ITipoPrestamoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoPrestamo> _paginator;

        public TipoPrestamoRepository(ApplicationDbContext context, IPaginator<TipoPrestamo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<TipoPrestamo> Create(TipoPrestamo entity)
        {
            _context.TipoPrestamo.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TipoPrestamo?> Disable(int id)
        {
            var model = await _context.TipoPrestamo.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.TipoPrestamo.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoPrestamo?> Edit(int id, TipoPrestamo entity)
        {
            var model = await _context.TipoPrestamo.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Codigo = entity.Codigo;
                model.Descripcion = entity.Descripcion;

                _context.TipoPrestamo.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoPrestamo?> Find(int id)
        => await _context.TipoPrestamo.FindAsync(id);

        public async Task<IList<TipoPrestamo>> FindAll()
        => await _context.TipoPrestamo
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<TipoPrestamo>> PaginatedSearch(RequestPagination<TipoPrestamo> entity)
        {
            var filter = entity.Filter;
            var query = _context.TipoPrestamo.AsQueryable();

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
