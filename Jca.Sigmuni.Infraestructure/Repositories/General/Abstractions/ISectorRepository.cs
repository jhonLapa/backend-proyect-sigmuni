using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ISectorRepository
    {
        Task<Sector> BuscarPorIdCartoAsync(string id);
        Task<Sector> BuscarPorIdCartoNoBorradoAsync(string id);
        Task<Sector> BuscarPorCodigoAsync(string codigo);
        Task<ResponsePagination<Sector>> PaginatedSearch(RequestPagination<Sector> entity);
    }
}
