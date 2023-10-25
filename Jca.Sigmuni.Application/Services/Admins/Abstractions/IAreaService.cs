using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.Admins.Abstractions
{
    public interface IAreaService : IServiceCrud<AreaDto, AreaFormDto, int>, IServicePaginated<AreaDto>
    {
        Task<IList<AreaDto>> SelectAll();
        Task<ResponsePagination<AreaDto>> SelectPaginatedSearch(RequestPagination<AreaDto> dto);
    }
}
