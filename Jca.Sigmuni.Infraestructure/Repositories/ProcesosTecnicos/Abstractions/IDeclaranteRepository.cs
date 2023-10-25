using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IDeclaranteRepository : IRepositoryCrud<Declarante, int>, IRepositoryPaginated<Declarante>
    {
        Task<bool> EliminarAsync(int id);
        Task<Declarante?> FindById(int? id);
    }
}
