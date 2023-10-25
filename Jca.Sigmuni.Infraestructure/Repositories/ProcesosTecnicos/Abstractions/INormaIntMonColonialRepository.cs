using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface INormaIntMonColonialRepository : IRepositoryCrud<NormaIntMonColonial, int>
    {
        Task<NormaIntMonColonial> BuscarPorIdAsync(int id);
        Task<List<NormaIntMonColonial>> ListarPorIdMonumentoColonialAsync(int idMonumentoColonial);
    }
}
