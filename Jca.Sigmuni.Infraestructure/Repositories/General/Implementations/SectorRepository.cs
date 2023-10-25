using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class SectorRepository : ISectorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Sector> _paginator;

        public SectorRepository(ApplicationDbContext context, IPaginator<Sector> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Sector> BuscarPorIdCartoNoBorradoAsync(string id)
       => await _context.Sectores.Where(e => e.Id == id && e.Estado == true).FirstOrDefaultAsync();
        public async Task<Sector> BuscarPorIdCartoAsync(string id)
        => await _context.Sectores.Where(e => e.Id == id).FirstOrDefaultAsync();


        public async Task<Sector> BuscarPorCodigoAsync(string codigo)
       => await _context.Sectores.Where(x => x.Codigo == codigo).FirstOrDefaultAsync();



        public async Task<ResponsePagination<Sector>> PaginatedSearch(RequestPagination<Sector> entity)
        {

            var filter = entity.Filter;
            var query = _context.Sectores
            .Include(x => x.Ubigeo)
            .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Id) || e.Id.ToUpper().Contains(filter.Id.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                     && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.CodigoUbigeo.ToUpper().Contains(filter.CodigoUbigeo.ToUpper().Trim()))
                   // && (string.IsNullOrWhiteSpace(filter.EstadoNombre) || e.EstadoNombre.ToUpper().Contains(filter.EstadoNombre.ToUpper().Trim()))


                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }

    }
}
