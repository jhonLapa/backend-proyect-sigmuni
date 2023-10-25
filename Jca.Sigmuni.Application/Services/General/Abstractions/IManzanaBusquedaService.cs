using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IManzanaBusquedaService 
    {
        Task<IList<ManzanaDto>> FindAll();
        Task<ResponsePagination<ManzanaDto>> PaginatedSearch(RequestPagination<ManzanaDto> dto);


    }
}
