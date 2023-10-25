using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class RepresentanteLegalRepository : IRepresentanteLegalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<RepresentanteLegal> _paginator;

        public RepresentanteLegalRepository(ApplicationDbContext context, IPaginator<RepresentanteLegal> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<RepresentanteLegal> Create(RepresentanteLegal entity)
        {
            _context.RepresentantesLegales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<RepresentanteLegal?> Disable(int id)
        {
            var model = await _context.RepresentantesLegales.FindAsync(id);

            if (model != null)
            {
                model.Estado = !model.Estado;

                _context.RepresentantesLegales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<RepresentanteLegal?> Edit(int id, RepresentanteLegal entity)
        {
            var model = await _context.RepresentantesLegales.FindAsync(id);

            if (model != null)
            {
                model.Codigo = entity.Codigo;

                _context.RepresentantesLegales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<RepresentanteLegal?> Find(int id)
         => await _context.RepresentantesLegales.FindAsync(id);

        public async Task<IList<RepresentanteLegal>> FindAll()
        => await _context.RepresentantesLegales.OrderByDescending(e => e.Id).ToListAsync();

        public async Task<ResponsePagination<RepresentanteLegal>> PaginatedSearch(RequestPagination<RepresentanteLegal> entity)
        {
            var filter = entity.Filter;
            var query = _context.RepresentantesLegales.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo == filter.Codigo)
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}
