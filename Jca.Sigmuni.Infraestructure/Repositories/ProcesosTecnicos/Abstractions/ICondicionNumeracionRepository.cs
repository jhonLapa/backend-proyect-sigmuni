using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICondicionNumeracionRepository
    {
        Task<IList<CondicionNumeracion>> FindAll();
    }
}
