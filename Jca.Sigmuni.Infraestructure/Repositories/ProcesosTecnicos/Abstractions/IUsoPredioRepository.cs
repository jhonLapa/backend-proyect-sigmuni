using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IUsoPredioRepository
    {
        Task<IList<UsoPredio>> FindAll();
    }
}
