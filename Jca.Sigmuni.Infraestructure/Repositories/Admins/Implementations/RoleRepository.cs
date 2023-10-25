using System;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Role> _paginator;

        public RoleRepository(ApplicationDbContext context, IPaginator<Role> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Role> Create(Role entity)
        {
            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Role?> Edit(int id, Role entity)
        {
            var model = await _context.Roles.FindAsync(id);

            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Descripcion = entity.Descripcion;

                _context.Roles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Role?> Disable(int id)
        {
            var model = await _context.Roles.FindAsync(id);

            if( model != null)
            {
                model.Estado = false;

                _context.Roles.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Role?> Find(int id)
        => await _context.Roles.FindAsync(id);

        public async Task<IList<Role>> FindAll()
        => await _context.Roles
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Role>> PaginatedSearch(RequestPagination<Role> entity)
        {
            
            var filter = entity.Filter;
            var query = _context.Roles.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                    && (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
             
        }
    }
}

