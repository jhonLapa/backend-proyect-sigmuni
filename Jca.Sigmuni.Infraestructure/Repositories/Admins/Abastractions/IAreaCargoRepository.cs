using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
    public interface IAreaCargoRepository : IRepositoryCrud<AreaCargo, int>, IRepositoryPaginated<AreaCargo>
    {
    }
}
