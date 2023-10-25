using System;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Core.Services
{
	public interface IServicePaginated<TDto>
    {
        Task<ResponsePagination<TDto>> PaginatedSearch(RequestPagination<TDto> dto);
    }
}


