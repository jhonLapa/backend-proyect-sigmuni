using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ISectorService
    {
        Task<ResponsePagination<SectorDto>> PaginatedSearch(RequestPagination<SectorDto> dto);
    }
}
