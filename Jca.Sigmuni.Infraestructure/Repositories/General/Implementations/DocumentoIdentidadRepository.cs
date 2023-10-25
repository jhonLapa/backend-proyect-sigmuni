using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class DocumentoIdentidadRepository : IDocumentoIdentidadRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<DocumentoIdentidad> _paginator;

        public DocumentoIdentidadRepository(ApplicationDbContext context, IPaginator<DocumentoIdentidad> paginator)
        { 
            _context = context;
            _paginator = paginator;
        }
        public async Task<DocumentoIdentidad> Create(DocumentoIdentidad entity)
        {
            _context.DocumentoIdentidades.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task<DocumentoIdentidad?> Disable(int id)
        {
            var model = await _context.DocumentoIdentidades.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.DocumentoIdentidades.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<DocumentoIdentidad?> Edit(int id, DocumentoIdentidad entity)
        {
            var model = await _context.DocumentoIdentidades.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Estado = entity.Estado;

                _context.DocumentoIdentidades.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<DocumentoIdentidad?> Find(int id)
         => await _context.DocumentoIdentidades.FindAsync(id);

        public async Task<IList<DocumentoIdentidad>> FindAll()
        => await _context.DocumentoIdentidades.Where(e => e.Estado == true)
            .OrderByDescending(e => e.Id)
            .ToListAsync();

        public async Task<ResponsePagination<DocumentoIdentidad>> PaginatedSearch(RequestPagination<DocumentoIdentidad> entity)
        {
            var filter = entity.Filter;
            var query = _context.DocumentoIdentidades.AsQueryable();

            if (filter != null)
            {
                query = query.Where(e =>
                 (string.IsNullOrWhiteSpace(filter.Codigo) || e.Codigo.ToUpper().Contains(filter.Codigo.ToUpper().Trim()))
                 && 
                 (string.IsNullOrWhiteSpace(filter.Nombre) || e.Nombre.ToUpper().Contains(filter.Nombre.ToUpper().Trim()))
                 &&
                (string.IsNullOrWhiteSpace(filter.Descripcion) || e.Descripcion.ToUpper().Contains(filter.Descripcion.ToUpper().Trim()))
                );
            }

            query = query.OrderByDescending(e => e.Id);

            var response = await _paginator.Paginate(query, entity);

            return response;
        }
    }
}
