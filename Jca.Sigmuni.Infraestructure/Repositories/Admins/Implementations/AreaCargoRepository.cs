using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class AreaCargoRepository : IAreaCargoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<AreaCargo> _paginator;

        public AreaCargoRepository(ApplicationDbContext context, IPaginator<AreaCargo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<AreaCargo> Create(AreaCargo entity)
        {
            _context.AreaCargos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<AreaCargo?> Edit(int id, AreaCargo entity)
        {
            var model = await _context.AreaCargos.FindAsync(id);

            if (model != null)
            {
                model.IdCargo = entity.IdCargo;
                model.IdArea = entity.IdArea;

                _context.AreaCargos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AreaCargo?> Disable(int id)
        {
            var model = await _context.AreaCargos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.AreaCargos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<AreaCargo?> Find(int id)
        => await _context.AreaCargos.Include(x => x.Cargo)
            .Include(x => x.Area).AsNoTracking()
                .DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.Id.Equals(id));
            
            //.FindAsync(id);

        public async Task<IList<AreaCargo>> FindAll()
        => await _context.AreaCargos
            .Include(x => x.Cargo)
            .Include(x => x.Area)
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<AreaCargo>> PaginatedSearch(RequestPagination<AreaCargo> entity)
        {

            var filter = entity.Filter;
            var query = _context.AreaCargos
                .Include(x => x.Cargo)
                .Include(x => x.Area)
                .AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}


