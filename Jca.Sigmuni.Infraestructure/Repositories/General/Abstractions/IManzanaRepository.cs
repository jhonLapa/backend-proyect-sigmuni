using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IManzanaRepository 
    {
        Task<IList<Manzana>> FindAll();
        Task<Manzana> BuscarPoManzanaAsync(string Codigo);
        Task<Manzana> BuscarPorIdSectorYCodManzanaAsync(string Sector, string codManzana);
        Task<Manzana> BuscarPorIdManzanaCartografica(string IdManzanaCartografica);
        Task<Manzana> BuscarPorCodigoManzana(string codigo);
        Task<ResponsePagination<Manzana>> PaginatedSearch(RequestPagination<Manzana> entity);
        Task<Manzana?> Find(string id);
        Task<Manzana> BuscarPorIdCartoNoBorradoAsync(string id);
    }
}
