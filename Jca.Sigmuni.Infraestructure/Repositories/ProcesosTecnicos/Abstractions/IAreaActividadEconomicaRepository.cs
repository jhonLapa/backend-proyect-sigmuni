using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IAreaActividadEconomicaRepository : IRepositoryCrud<AreaActividadEconomica, int>
    {
        Task<AreaActividadEconomica> BuscarPorIdAsync(int id);
    }
}
