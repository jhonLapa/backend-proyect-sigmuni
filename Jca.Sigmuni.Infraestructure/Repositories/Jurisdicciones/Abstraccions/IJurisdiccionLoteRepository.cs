using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Jurisdicciones.Abstraccions
{
    public interface IJurisdiccionLoteRepository : IRepositoryCrud<JurisdiccionLote, int>
    {
        Task<ResponsePagination<JurisdiccionLote>> PaginatedSearch(RequestPagination<JurisdiccionLote> entity);
    }
}
