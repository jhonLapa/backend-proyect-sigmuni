using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Vias.Abstractions
{
    public interface IViaRepository : IRepositoryCrud<Via, int>
    {
        Task<Via> BuscarPorIdYNoBorradoAsync(string id);
        Task<Via> BuscarPorIdAsync(string id);
        Task<Via> BuscarPorCodigoViaAsync(string codVia);
        Task<ResponsePagination<Via>> PaginatedSearch(RequestPagination<Via> entity);
    }
}
