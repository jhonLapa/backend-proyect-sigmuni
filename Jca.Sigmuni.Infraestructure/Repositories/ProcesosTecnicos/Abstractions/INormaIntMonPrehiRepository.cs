using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface INormaIntMonPrehiRepository : IRepositoryCrud<NormaIntMonPrehi, int>
    {
        Task<NormaIntMonPrehi> BuscarPorIdAsync(int id);
        Task<List<NormaIntMonPrehi>> ListarPorIdMonumentoPreAsync(int? idMonumentoPre); 
    }
}
