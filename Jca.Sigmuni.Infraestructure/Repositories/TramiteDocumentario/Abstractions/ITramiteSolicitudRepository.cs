using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface ITramiteSolicitudRepository
    {
        Task<ResponsePagination<TramiteSolicitud>> PaginatedSearch(RequestPagination<TramiteSolicitud> entity);

    }
}
