using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoLitiganteRepository
    {
        Task<IList<TipoLitigante>> FindAll();
    }
}
