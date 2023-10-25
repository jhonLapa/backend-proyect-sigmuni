using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoInspeccionRepository
    {
        Task<IList<TipoInspeccion>> FindAll();
    }
}
