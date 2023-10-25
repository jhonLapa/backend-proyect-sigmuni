using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICondicionConductorRepository
    {
        Task<IList<CondicionConductor>> FindAll();
    }
}
