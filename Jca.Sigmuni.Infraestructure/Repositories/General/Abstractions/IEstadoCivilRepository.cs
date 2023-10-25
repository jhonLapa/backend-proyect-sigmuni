using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface IEstadoCivilRepository : IRepositoryCrud<EstadoCivil, int>, IRepositoryPaginated<EstadoCivil>
    {
    }
}
