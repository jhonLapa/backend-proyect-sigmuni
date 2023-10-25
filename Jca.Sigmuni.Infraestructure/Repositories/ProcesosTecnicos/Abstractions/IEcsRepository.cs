using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IEcsRepository
    {
        Task<IList<Ecs>> FindAll();
    }
}
