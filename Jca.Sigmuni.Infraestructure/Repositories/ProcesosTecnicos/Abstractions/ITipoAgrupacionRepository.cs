using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoAgrupacionRepository
    {
        Task<TipoAgrupacion?> TipoAgrupacionDefaultAsync();
        Task<IList<TipoAgrupacion>> FindAll();
    }
}
