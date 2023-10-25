using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IConductorRepository : IRepositoryCrud<Conductor, int>
    {
        Task<Conductor> BuscarPorIdPersonaAsync(int idPersona);
        Task<Conductor> BuscarPorIdAsync(int id);
    }
}
