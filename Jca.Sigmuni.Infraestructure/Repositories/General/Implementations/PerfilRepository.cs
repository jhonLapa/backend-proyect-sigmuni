using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Perfil> _paginator;

        public PerfilRepository(ApplicationDbContext context, IPaginator<Perfil> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Perfil> Create(Perfil entity)
        {
            _context.Perfils.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Perfil?> Edit(int id, Perfil entity)
        {
            var model = await _context.Perfils.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Nombre = entity.Nombre;
                model.Etiqueta = entity.Etiqueta;


                _context.Perfils.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Perfil?> Disable(int id)
        {
            var model = await _context.Perfils.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Perfils.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Perfil?> Find(int id)
        => await _context.Perfils.FindAsync(id);

        public async Task<IList<Perfil>> FindAll()
        => await _context.Perfils
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Perfil>> PaginatedSearch(RequestPagination<Perfil> entity)
        {

            var filter = entity.Filter;
            var query = _context.Perfils.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Etiqueta) || e.Etiqueta.ToUpper().Contains(filter.Etiqueta.ToUpper().Trim()))

                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
