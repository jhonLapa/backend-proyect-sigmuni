using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IClasificacionPredioRepository
    {
        Task<IList<ClasificacionPredio>> FindAll();
    }
}
