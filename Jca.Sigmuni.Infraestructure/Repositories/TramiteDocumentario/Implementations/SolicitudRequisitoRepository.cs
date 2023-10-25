using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Context;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class SolicitudRequisitoRepository : ISolicitudRequisitoRepository
    {

        private readonly ApplicationDbContext _context;
        
        public SolicitudRequisitoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<SolicitudRequisito> Create(SolicitudRequisito entity)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudRequisito?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudRequisito?> Edit(int id, SolicitudRequisito entity)
        {
            throw new NotImplementedException();
        }

        public async Task<SolicitudRequisito?> EliminarDocumentoSolicitudRequisito(int idSolicitudRequisito)
        {
            var model = await _context.SolicitudRequisitos.FindAsync(idSolicitudRequisito);
            if(model !=null)
            {
                model.IdDocumento = null;
                _context.SolicitudRequisitos.Update(model);
                await _context.SaveChangesAsync();
            }
            return model;

        }

        public Task<SolicitudRequisito?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SolicitudRequisito>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<SolicitudRequisito>> PaginatedSearch(RequestPagination<SolicitudRequisito> entity)
        {
            throw new NotImplementedException();
        }
    }
}
