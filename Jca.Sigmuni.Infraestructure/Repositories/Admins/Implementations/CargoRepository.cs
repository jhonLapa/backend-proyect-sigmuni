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
    public class CargoRepository : ICargoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Cargo> _paginator;

        public CargoRepository(ApplicationDbContext context, IPaginator<Cargo> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Cargo> Create(Cargo entity)
        {
            _context.Cargos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<Cargo?> Edit(int id, Cargo entity)
        {
            var model = await _context.Cargos.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;

                _context.Cargos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Cargo?> Disable(int id)
        {
            var model = await _context.Cargos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Cargos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Cargo?> Find(int id)
        => await _context.Cargos.FindAsync(id);

        public async Task<IList<Cargo>> FindAll()
        => await _context.Cargos
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<Cargo>> PaginatedSearch(RequestPagination<Cargo> entity)
        {

            var filter = entity.Filter;
            var query = _context.Cargos.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                    (!filter.Estado.HasValue || e.Estado == filter.Estado)
                    && (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;

        }
    }
}
