using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IAntiguedadRepository : IRepositoryBase<Antiguedad, int>
    {
        Task<List<Antiguedad>> ListarGlobalAsync();
        Task<Antiguedad?> BuscarPorLimitesAsync(int antiguedad);
    }
}
