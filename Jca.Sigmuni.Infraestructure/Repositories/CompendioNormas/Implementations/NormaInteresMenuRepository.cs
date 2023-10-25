using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Implementations
{
    public class NormaInteresMenuRepository : INormaInteresMenuRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<NormaInteresMenu> _paginator;

        public NormaInteresMenuRepository(ApplicationDbContext context, IPaginator<NormaInteresMenu> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<NormaInteresMenu> Create(NormaInteresMenu entity)
        {
            _context.NormaInteresMenus.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<NormaInteresMenu?> Disable(int id)
        {
            var model = await _context.NormaInteresMenus.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.NormaInteresMenus.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<NormaInteresMenu?> Edit(int id, NormaInteresMenu entity)
        {
            var model = await _context.NormaInteresMenus.FindAsync(id);

            if (model != null)
            {
                model.Estado = entity.Estado;

                _context.NormaInteresMenus.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }


        public async Task<NormaInteresMenu?> Find(int id)
        => await _context.NormaInteresMenus.Include(x => x.Menu)
                .DefaultIfEmpty()
                .FirstOrDefaultAsync(i => i.IdNormaInteresMenu.Equals(id));

        public async Task<IList<NormaInteresMenu>> FindAll()
        => await _context.NormaInteresMenus
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.IdNormaInteresMenu)
            .ToListAsync();

        public async Task<ResponsePagination<NormaInteresMenu>> PaginatedSearch(RequestPagination<NormaInteresMenu> entity)
        {
            throw new NotImplementedException();
        }
        public async Task<List<NormaInteresMenu>> BuscarPorIdNormaInteres(int idNormaInteresMenu)
            => await _context.NormaInteresMenus.Include(x => x.Menu)
            .Where(e => e.IdNormaInteres == idNormaInteresMenu)
            .OrderByDescending(e => e.IdNormaInteresMenu)
            .ToListAsync();
    }
}
