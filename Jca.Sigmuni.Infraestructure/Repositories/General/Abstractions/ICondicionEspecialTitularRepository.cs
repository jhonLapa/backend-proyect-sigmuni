using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions
{
    public interface ICondicionEspecialTitularRepository
    {
        Task<IList<CondicionEspecialTitular>> FindAll();
    }
}
