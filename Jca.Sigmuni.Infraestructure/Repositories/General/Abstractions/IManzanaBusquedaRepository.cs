using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IManzanaBusquedaRepository 
    {
        Task<IList<Manzana>> FindAll();

        Task<ResponsePagination<Manzana>> PaginatedSearch(RequestPagination<Manzana> entity);
    }
}
