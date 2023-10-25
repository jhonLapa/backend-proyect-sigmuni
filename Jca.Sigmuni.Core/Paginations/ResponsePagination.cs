using System;
namespace Jca.Sigmuni.Core.Paginations
{
	public class ResponsePagination<T> : Pagination
    {
        public ResponsePagination()
        {
        }

        public ResponsePagination(int total, int page, int perPage) : base(total, page, perPage) { }

        public ResponsePagination(Pagination pagination) : base(pagination) { }

        public IList<T> Data { get; set; }
    }
}

