using System;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Infraestructure.Core.Paginations.Abstractions
{
	public interface IPaginator<T>
    {
        Task<ResponsePagination<T>> Paginate(IQueryable<T> query, RequestPagination<T> request);
    }
}

