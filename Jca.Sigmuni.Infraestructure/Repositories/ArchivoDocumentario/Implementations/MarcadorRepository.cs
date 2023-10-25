using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class MarcadorRepository : IMarcadorRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<Marcador> _paginator;

        public MarcadorRepository(ApplicationDbContext context, IPaginator<Marcador> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<Marcador> Create(Marcador entity)
        {
            _context.Marcadores.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Marcador?> Edit(int id, Marcador entity)
        {
            var model = await _context.Marcadores.FindAsync(id);

            if (model != null)
            {
                model.Pagina = entity.Pagina;
                model.Descripcion = entity.Descripcion;

                _context.Marcadores.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Marcador?> Disable(int id)
        {
            var model = await _context.Marcadores.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Marcadores.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Marcador?> Find(int id)
        => await _context.Marcadores.FindAsync(id);

        public async Task<IList<Marcador>> FindAll()
        => await _context.Marcadores
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();
        public async Task<ResponsePagination<Marcador>> PaginatedSearch(RequestPagination<Marcador> entity)
        {

            var filter = entity.Filter;
            var query = _context.Marcadores.AsQueryable();

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
