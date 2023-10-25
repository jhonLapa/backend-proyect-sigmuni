using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class EstadoCivilRepository : IEstadoCivilRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<EstadoCivil> _paginator;

        public EstadoCivilRepository(ApplicationDbContext context, IPaginator<EstadoCivil> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<EstadoCivil> Create(EstadoCivil entity)
        {
            _context.EstadoCivils.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<EstadoCivil?> Edit(int id, EstadoCivil entity)
        {
            var model = await _context.EstadoCivils.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Codigo = entity.Codigo;


                _context.EstadoCivils.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<EstadoCivil?> Disable(int id)
        {
            var model = await _context.EstadoCivils.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.EstadoCivils.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<EstadoCivil?> Find(int id)
        => await _context.EstadoCivils.FindAsync(id);

        public async Task<IList<EstadoCivil>> FindAll()
        => await _context.EstadoCivils
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<EstadoCivil>> PaginatedSearch(RequestPagination<EstadoCivil> entity)
        {

            var filter = entity.Filter;
            var query = _context.EstadoCivils.AsQueryable();

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
