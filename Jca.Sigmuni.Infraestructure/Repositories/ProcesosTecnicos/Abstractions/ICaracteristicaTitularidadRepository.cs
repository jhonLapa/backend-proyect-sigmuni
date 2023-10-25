using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICaracteristicaTitularidadRepository : IRepositoryCrud<CaracteristicaTitularidad, int>
    {
        Task<bool> EliminarAsync(int id);
    }
}
