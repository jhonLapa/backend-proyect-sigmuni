using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IEdificacionIndustrialRepository
    {
        Task<IList<EdificacionIndustrial>> FindAll();
    }
}
