using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Implementations
{
    public class MenuRepository : IMenuRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Menu> _paginator;

        public MenuRepository(ApplicationDbContext context, IPaginator<Menu> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<Menu> Create(Menu entity)
        {
            _context.Menus.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Menu?> Edit(int id, Menu entity)
        {
            var model = await _context.Menus.FindAsync(id);

            if (model != null)
            {
                model.Nombre = entity.Nombre;
                model.Icono = entity.Icono;
                model.url_menu = entity.url_menu;

                _context.Menus.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Menu?> Disable(int id)
        {
            var model = await _context.Menus.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Menus.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Menu?> Find(int id)
       => await _context.Menus.FindAsync(id);

        public async Task<IList<Menu>> FindAll()
        => await _context.Menus
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();
        public async Task<ResponsePagination<Menu>> PaginatedSearch(RequestPagination<Menu> entity)
        {

            var filter = entity.Filter;
            var query = _context.Menus.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
