using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Infraestructure.Core.Repositories;


namespace Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions
{
    public interface IMenuRepository : IRepositoryCrud<Menu, int>, IRepositoryPaginated<Menu>
    {
    }
}
