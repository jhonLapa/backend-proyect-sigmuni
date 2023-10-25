using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoDocNotarialRepository
    {
        Task<IList<TipoDocNotarial>> FindAll();
    }
}
