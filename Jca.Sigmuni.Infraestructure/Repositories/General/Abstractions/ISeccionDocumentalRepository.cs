using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ISeccionDocumentalRepository : IRepositoryCrud<SeccionDocumental, int>, IRepositoryPaginated<SeccionDocumental>
    {
    }
}
