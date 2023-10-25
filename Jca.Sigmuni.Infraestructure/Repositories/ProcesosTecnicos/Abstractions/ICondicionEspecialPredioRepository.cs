using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICondicionEspecialPredioRepository
    {
        Task<IList<CondicionEspecialPredio>> FindAll();
    }
}
