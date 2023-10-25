using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Implementations
{
    public class ZonificacionRepository : IZonificacionRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<ZonificacionParametro> _paginator;

        public ZonificacionRepository(ApplicationDbContext context, IPaginator<ZonificacionParametro> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public Task<ZonificacionParametro> Create(ZonificacionParametro entity)
        {
            throw new NotImplementedException();
        }

        public Task<ZonificacionParametro?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ZonificacionParametro?> Edit(int id, Via entity)
        {
            throw new NotImplementedException();
        }

        public Task<ZonificacionParametro?> Edit(int id, ZonificacionParametro entity)
        {
            throw new NotImplementedException();
        }

        public Task<ZonificacionParametro?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ZonificacionParametro>> FindAll()
        => await _context.ZonificacionParametros

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<ResponsePagination<ZonificacionParametro>> PaginatedSearch(RequestPagination<ZonificacionParametro> entity)
        {

            var filter = entity.Filter;
            var query = _context.ZonificacionParametros
            .AsQueryable();

            if (filter != null)
            {
                query = query.Include(e => e.Ubigeo).Include(e => e.AreaTratamiento).Include(e => e.ClaseZonificacion).Where(e =>
                    e.Estado == filter.Estado
                    && (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.CodigoUbigeo.ToUpper().Contains(filter.CodigoUbigeo.ToUpper().Trim())));
            }

            query = query.OrderBy(e => e.Codigo);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
