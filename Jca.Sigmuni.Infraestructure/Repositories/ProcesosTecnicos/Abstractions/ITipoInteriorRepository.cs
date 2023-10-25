using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoInteriorRepository
    {
        Task<IList<TipoInterior>> FindAll();
    }
}
