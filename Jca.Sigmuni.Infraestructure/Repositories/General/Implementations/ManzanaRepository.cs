using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class ManzanaRepository : IManzanaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Manzana> _paginator;

        public ManzanaRepository(ApplicationDbContext context, IPaginator<Manzana> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Manzana?> Find(string id)
       => await _context.Manzanas.Include(e => e.Sector)
           .DefaultIfEmpty()
               .FirstOrDefaultAsync(i => i.Id.Equals(id));


        public async Task<IList<Manzana>> FindAll()
       => await _context.Manzanas
           .Include(e => e.Sector)
           .Where(e => e.Estado == true)
           .OrderByDescending(e => e.Id)
           .ToListAsync();
        public async Task<Manzana> BuscarPoManzanaAsync(string Codigo)
        => await _context.Manzanas
            .Include(x => x.Sector)
            .Where(x => x.Codigo == Codigo).FirstOrDefaultAsync();

        public async Task<Manzana> BuscarPorIdSectorYCodManzanaAsync(string Sector, string codManzana)
      => await _context.Manzanas
          .Include(x => x.Sector)
          .Where(x => (x.IdSectorCarto == Sector) && (x.Codigo == codManzana)).FirstOrDefaultAsync();

        public async Task<Manzana> BuscarPorIdManzanaCartografica(string IdManzanaCartografica)
        => await _context.Manzanas
            .Include(x => x.Sector)
            .Where(x => x.Id == IdManzanaCartografica)
            .FirstOrDefaultAsync();
        public async Task<Manzana> BuscarPorIdCartoNoBorradoAsync(string id)
        => await _context.Manzanas
            .Include(e => e.Sector)
            .Where(e => e.Id == id).FirstOrDefaultAsync();

        public async Task<Manzana> BuscarPorCodigoManzana(string codigo)
            => await _context.Manzanas
            .Include(x => x.Sector)
            .Where(x => x.Codigo == codigo)
            .FirstOrDefaultAsync();
        public async Task<ResponsePagination<Manzana>> PaginatedSearch(RequestPagination<Manzana> entity)
        {

            var filter = entity.Filter;
            var query = _context.Manzanas
            .Include(e => e.Sector).ThenInclude(p => p.Ubigeo)
            .AsQueryable();

            if (filter != null)
            {
                var CodSec = filter.Sector?.Codigo;
                var CodUbigeo = filter.Sector?.Ubigeo?.Codigo;
                query = query.Where(e =>
                    e.Estado == true
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(CodSec) || e.Sector.Codigo == filter.Sector.Codigo)
                    && (string.IsNullOrWhiteSpace(CodUbigeo) || e.Sector.Ubigeo.Codigo == filter.Sector.Ubigeo.Codigo)
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
