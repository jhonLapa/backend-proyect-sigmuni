using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoPartidaRegistralRepository
    {
        Task<IList<TipoPartidaRegistral>> FindAll();
    }
}
