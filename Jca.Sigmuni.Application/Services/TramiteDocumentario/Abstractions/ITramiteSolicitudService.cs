using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ITramiteSolicitudService
    {
        Task<ResponsePagination<TramiteSolicitudDto>> PaginatedSearch(RequestPagination<TramiteSolicitudDto> dto);
    }
}
