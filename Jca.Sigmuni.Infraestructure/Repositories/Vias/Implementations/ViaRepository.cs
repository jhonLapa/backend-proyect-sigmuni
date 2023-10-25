using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Implementations;
using Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Vias.Implementations
{
    public class ViaRepository : IViaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Via> _paginator;

        public ViaRepository(ApplicationDbContext context, IPaginator<Via> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public Task<Via> Create(Via entity)
        {
            throw new NotImplementedException();
        }
        public  async Task<Via> BuscarPorIdYNoBorradoAsync(string id)
           => await _context.Vias.Where(e => e.IdVia == id && e.Estado == true)
               .FirstOrDefaultAsync();

        public  async Task<Via> BuscarPorIdAsync(string id)
            => await _context.Vias.Where(e => e.IdVia == id).FirstOrDefaultAsync();

        public async Task<Via> BuscarPorCodigoViaAsync(string codVia)
            => await _context.Vias.Where(x => x.CodVia == codVia)
                .FirstOrDefaultAsync();

        public Task<Via?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Via?> Edit(int id, Via entity)
        {
            throw new NotImplementedException();
        }

        public Task<Via?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Via>> FindAll()
        => await _context.Vias

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<ResponsePagination<Via>> PaginatedSearch(RequestPagination<Via> entity)
        {

            var filter = entity.Filter;
            var query = _context.Vias
            .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    e.Estado == filter.Estado
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.CodigoUbigeo.ToUpper().Contains(filter.CodigoUbigeo.ToUpper().Trim())));
            }

            query = query.OrderBy(e => e.CodVia);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
