using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class TipoPersonaRepository : ITipoPersonaRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<TipoPersona> _paginator;

        public TipoPersonaRepository(ApplicationDbContext context, IPaginator<TipoPersona> paginator)
        { 
            _context = context;
            _paginator = paginator;
        }
        public async Task<TipoPersona> Create(TipoPersona entity)
        {
            _context.TipoPersonas.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<TipoPersona?> Disable(int id)
        {
            var model = await _context.TipoPersonas.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.TipoPersonas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoPersona?> Edit(int id, TipoPersona entity)
        {
            var model = await _context.TipoPersonas.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Estado = entity.Estado;

                _context.TipoPersonas.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<TipoPersona?> Find(int id)
         => await _context.TipoPersonas.FindAsync(id);

        public async Task<IList<TipoPersona>> FindAll()
        => await _context.TipoPersonas.Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<TipoPersona>> PaginatedSearch(RequestPagination<TipoPersona> entity)
        {
            var filter = entity.Filter;
            var query = _context.TipoPersonas.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e => (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}
