using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoEvaluacionRepository
    {
        Task<IList<TipoEvaluacion>> FindAll();
    }
}
