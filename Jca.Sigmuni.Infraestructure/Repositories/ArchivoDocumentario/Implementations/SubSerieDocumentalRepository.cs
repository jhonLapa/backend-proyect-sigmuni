using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.ArchivoDocumentario.Implementations
{
    public class SubSerieDocumentalRepository : ISubSerieDocumentalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<SubSerieDocumental> _paginator;

        public SubSerieDocumentalRepository(ApplicationDbContext context, IPaginator<SubSerieDocumental> paginator)
        {
            _context = context;
            _paginator = paginator;
        }

        public async Task<SubSerieDocumental> Create(SubSerieDocumental entity)
        {
            _context.SubSerieDocumentales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<SubSerieDocumental?> Edit(int id, SubSerieDocumental entity)
        {
            var model = await _context.SubSerieDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Codigo = entity.Codigo;
                model.Descripcion = entity.Descripcion;

                _context.SubSerieDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SubSerieDocumental?> Disable(int id)
        {
            var model = await _context.SubSerieDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.SubSerieDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SubSerieDocumental?> Find(int id)
        => await _context.SubSerieDocumentales.FindAsync(id);

        public async Task<IList<SubSerieDocumental>> FindAll()
        => await _context.SubSerieDocumentales
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<SubSerieDocumental>> PaginatedSearch(RequestPagination<SubSerieDocumental> entity)
        {

            var filter = entity.Filter;
            var query = _context.SubSerieDocumentales.AsQueryable();

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
