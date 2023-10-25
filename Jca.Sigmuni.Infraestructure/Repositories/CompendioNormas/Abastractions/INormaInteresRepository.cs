using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.CompendioNormas.Abastractions
{
    public interface  INormaInteresRepository : IRepositoryCrud<NormaInteres, int>, IRepositoryPaginated<NormaInteres>
    {
        Task<ResponsePagination<NormaInteres>> PaginatedSearchFiltros(RequestPagination<NormaInteres> entity, string? fechaRegistroDesde, string? fechaRegistroHasta);
    }
}
