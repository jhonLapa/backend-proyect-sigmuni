using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Implementations
{
    public class SolicitudCucRepository : ISolicitudCucRepository
    {
        public Task<SolicitudCuc> Create(SolicitudCuc entity)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudCuc?> Disable(int id)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudCuc?> Edit(int id, SolicitudCuc entity)
        {
            throw new NotImplementedException();
        }

        public Task<SolicitudCuc?> Find(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IList<SolicitudCuc>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePagination<SolicitudCuc>> PaginatedSearch(RequestPagination<SolicitudCuc> entity)
        {
            throw new NotImplementedException();
        }
    }
}
