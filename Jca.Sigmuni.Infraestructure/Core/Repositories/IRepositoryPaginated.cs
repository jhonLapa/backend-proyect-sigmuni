using System;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Infraestructure.Core.Repositories
{
	public interface IRepositoryPaginated<T>
	{
        Task<ResponsePagination<T>> PaginatedSearch(RequestPagination<T> entity);
    }
}

