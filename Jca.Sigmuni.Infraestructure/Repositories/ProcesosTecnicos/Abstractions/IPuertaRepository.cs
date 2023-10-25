using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IPuertaRepository : IRepositoryCrud<Puerta, int>
    {
        Task<List<Puerta>> ListarPorUbicacionPredioAsync(int idUbicacionPredio);
        Task<bool> EliminarAsync(int id);
        
    }
}
