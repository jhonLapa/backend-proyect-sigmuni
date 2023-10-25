using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEvaluaciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoEvaluacionService
    {
        Task<IList<TipoEvaluacionDto>> FindAll();
    }
}
