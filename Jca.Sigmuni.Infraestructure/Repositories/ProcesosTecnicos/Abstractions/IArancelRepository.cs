using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IArancelRepository : IRepositoryBase<Arancel, int>
    {
        Task<Arancel?> Edit(int id, Arancel entity);
        Task<Arancel> BuscarPorIdViaAsync(string idVia);
        Task<Arancel> BuscarPorIdManzanaAsync(string idManzana);
        Task<Arancel> BuscarPorIdManzanaIdViaAsync(string idManzana, string idVia);
        
        Task<ResponsePagination<Arancel>> PaginatedSearch(RequestPagination<ArancelBusqueda> entity);
    }
}
