using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoEdificacionRepository
    {
        Task<IList<TipoEdificacion>> FindAll();
        Task<TipoEdificacion?> TipoEdificacionDefaultAsync();
    }
}
