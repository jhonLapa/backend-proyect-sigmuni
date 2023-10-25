using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class RequisitoRepository : IRequisitoRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Requisito> _paginator;

        public RequisitoRepository(ApplicationDbContext context, IPaginator<Requisito> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Requisito> Create(Requisito entity)
        {
            _context.Requisitos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Requisito?> Disable(int id)
        {
            var model = await _context.Requisitos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Requisitos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Requisito?> Edit(int id, Requisito entity)
        {
            var model = await _context.Requisitos.FindAsync(id);

            if (model != null)
            {
                model.Codigo = entity.Codigo;
                model.Descripcion = entity.Descripcion;

                _context.Requisitos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Requisito?> Find(int id)
        => await _context.Requisitos.DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.Id.Equals(id));

        public async Task<IList<Requisito>> FindAll()
       => await _context.Requisitos
           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<ResponsePagination<Requisito>> PaginatedSearch(RequestPagination<Requisito> entity)
        {

            var filter = entity.Filter;
            var query = _context.Requisitos
            .AsQueryable();

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
