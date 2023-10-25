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
    public class SerieDocumentalRepository : ISerieDocumentalRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<SerieDocumental> _paginator;

        public SerieDocumentalRepository(ApplicationDbContext context, IPaginator<SerieDocumental> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<SerieDocumental> Create(SerieDocumental entity)
        {
            _context.SerieDocumentales.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<SerieDocumental?> Edit(int id, SerieDocumental entity)
        {
            var model = await _context.SerieDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Codigo = entity.Codigo;
                model.Descripcion = entity.Descripcion;
                model.Codigo = entity.Codigo;
                model.Siglas = entity.Siglas;

                _context.SerieDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SerieDocumental?> Disable(int id)
        {
            var model = await _context.SerieDocumentales.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.SerieDocumentales.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<SerieDocumental?> Find(int id)
        => await _context.SerieDocumentales.FindAsync(id);

        public async Task<IList<SerieDocumental>> FindAll()
        => await _context.SerieDocumentales
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<SerieDocumental>> PaginatedSearch(RequestPagination<SerieDocumental> entity)
        {

            var filter = entity.Filter;
            var query = _context.SerieDocumentales.AsQueryable();

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
