using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IMonumentoColonialRepository : IRepositoryCrud<MonumentoColonial, int>
    {
        Task<MonumentoColonial?> BuscarPorIdAsync(int id);
    }
}
