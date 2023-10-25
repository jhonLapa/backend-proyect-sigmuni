using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICondicionTitularRepository
    {
        Task<IList<CondicionTitular>> FindAll();
    }
}
