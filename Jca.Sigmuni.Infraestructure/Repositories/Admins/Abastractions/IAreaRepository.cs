using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
    public interface IAreaRepository : IRepositoryCrud<Area, int>, IRepositoryPaginated<Area>
    {
        Task<IList<Area>> SelectAll();
        Task<ResponsePagination<Area>> SelectPaginatedSearch(RequestPagination<Area> entity);
    }
}
