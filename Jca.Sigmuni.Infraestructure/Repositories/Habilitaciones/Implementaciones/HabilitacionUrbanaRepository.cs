using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Implementaciones
{
    public class HabilitacionUrbanaRepository : IHabilitacionUrbanaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<HabilitacionUrbana> _paginator;

        public HabilitacionUrbanaRepository(ApplicationDbContext context, IPaginator<HabilitacionUrbana> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<HabilitacionUrbana> Create(HabilitacionUrbana entity)
        {
            _context.HabilitacionUrbanas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public Task<HabilitacionUrbana?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<HabilitacionUrbana?> Edit(int id, HabilitacionUrbana entity)
        {
            throw new NotImplementedException();
        }

        public async Task<HabilitacionUrbana?> Find(int id)
        => await _context.HabilitacionUrbanas.DefaultIfEmpty()
            .FirstOrDefaultAsync(i => i.IdHabilitacionUrbana.Equals(id));

        public async Task<IList<HabilitacionUrbana>> FindAll()
        => await _context.HabilitacionUrbanas

            .Where(e => e.Estado == true)
            .ToListAsync();

        public async Task<HabilitacionUrbana?> BuscarPorIdHUCartoAsync(string id)
        => await _context.HabilitacionUrbanas.DefaultIfEmpty()
            .FirstOrDefaultAsync(i => i.IdHUCarto == id);

        public async Task<ResponsePagination<HabilitacionUrbana>> PaginatedSearch(RequestPagination<HabilitacionUrbana> entity)
        {

            var filter = entity.Filter;
            var query = _context.HabilitacionUrbanas
            .AsQueryable();

            if (filter != null)
            {
                query = query.Include(e => e.TipoHabilitacionUrbana).Where(e =>
                    e.Estado == true
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.CodigoHabilitacioUrbana) || e.CodigoHabilitacioUrbana.ToUpper().Contains(filter.CodigoHabilitacioUrbana.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.CodigoUbigeo) || e.CodigoUbigeo.ToUpper().Contains(filter.CodigoUbigeo.ToUpper().Trim())));
            }

            query = query.OrderBy(e => e.CodigoUbigeo).ThenBy(e => e.CodigoHabilitacioUrbana);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
