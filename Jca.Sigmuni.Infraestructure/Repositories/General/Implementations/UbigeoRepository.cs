using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class UbigeoRepository : IUbigeoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Ubigeo> _paginator;

        public UbigeoRepository(ApplicationDbContext context, IPaginator<Ubigeo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }




        public async Task<IList<Ubigeo>> FindAll()
       => await _context.Ubigeos

           .Where(e => e.Estado == true)
           .ToListAsync();

        public async Task<ResponsePagination<Ubigeo>> PaginatedSearch(RequestPagination<Ubigeo> entity)
        {

            var filter = entity.Filter;
            var query = _context.Ubigeos

            .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.EstadoNombre) || e.EstadoNombre.ToUpper().Contains(filter.EstadoNombre.ToUpper().Trim()))


                );
            }

            query = query.OrderByDescending(e => e.Codigo);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

        public async Task<Ubigeo?> UbigeoDefaultAsync()
        => await _context.Ubigeos.Where(e => e.Codigo == "150101").FirstOrDefaultAsync();

        public async Task<Ubigeo?> BuscarPorCodigoAsync(string codigo)
        => await _context.Ubigeos.Where(e => e.Codigo == codigo && e.Estado == true).FirstOrDefaultAsync();

        public async Task<List<Ubigeo>> ListarPorCodigo(string codigo)
        =>await _context.Ubigeos.Where(e=>e.CodigoPadre==codigo).ToListAsync();
    }
}
