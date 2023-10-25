using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IUbigeoRepository
    {
        Task<IList<Ubigeo>> FindAll();
        Task<ResponsePagination<Ubigeo>> PaginatedSearch(RequestPagination<Ubigeo> entity);
        Task<Ubigeo?> UbigeoDefaultAsync();
        Task<Ubigeo?> BuscarPorCodigoAsync(string codigo);
        Task<List<Ubigeo>> ListarPorCodigo(string codigo);
    }
}
