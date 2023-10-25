using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IInfoComplementarioRepository : IRepositoryCrud<InfoComplementario, int>, IRepositoryPaginated<InfoComplementario>
    {
    }
}
