using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Habilitaciones.Abstracciones
{
    public interface IHabilitacionUrbanaRepository : IRepositoryCrud<HabilitacionUrbana, int>
    {
        Task<HabilitacionUrbana?> BuscarPorIdHUCartoAsync(string id);
        Task<ResponsePagination<HabilitacionUrbana>> PaginatedSearch(RequestPagination<HabilitacionUrbana> entity);
    }
}
