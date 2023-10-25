using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IMonumentoPrehispanicoRepository : IRepositoryCrud<MonumentoPrehispanico, int>
    {
        Task<MonumentoPrehispanico?> BuscarPorIdAsync(int id);
        
    }
}
