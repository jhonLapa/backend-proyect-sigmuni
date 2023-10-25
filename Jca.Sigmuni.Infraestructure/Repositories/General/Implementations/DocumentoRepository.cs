using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Implementations
{
    public class DocumentoRepository : IDocumentoRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaginator<DocumentoB64> _paginator;

        public DocumentoRepository(ApplicationDbContext context, IPaginator<DocumentoB64> paginator)
        {
            _context = context;
            _paginator = paginator;
        }
        public async Task<Documento> Create(Documento entity)
        {
            _context.Documentos.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }
        public async Task<Documento?> Disable(int id)
        {
            var model = await _context.Documentos.FindAsync(id);

            if (model != null)
            {
                model.Estado = false;

                _context.Documentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }
        public async Task<Documento?> Edit(int id, Documento entity)
        {
            var model = await _context.Documentos.FindAsync(id);

            if (model != null)
            {
                model.Descripcion = entity.Descripcion;
                model.Estado = entity.Estado;

                _context.Documentos.Update(model);
                await _context.SaveChangesAsync();
            }

            return model;
        }

        public async Task<Documento?> Find(int id)
        => await _context.Documentos.FindAsync(id);

        public async Task<IList<Documento>> FindAll()
        => await _context.Documentos
            .Where(e => e.Estado == true)
            .OrderByDescending(e => e.IdDocumento)
            .ToListAsync();

        public async Task<ResponsePagination<Documento>> PaginatedSearch(RequestPagination<Documento> entity)
        {
            throw new NotImplementedException();
        }
    }
}
