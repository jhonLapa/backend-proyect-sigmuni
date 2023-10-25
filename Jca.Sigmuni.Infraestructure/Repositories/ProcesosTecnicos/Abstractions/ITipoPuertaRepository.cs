using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoPuertaRepository
    {
        Task<IList<TipoPuerta>> FindAll();
    }
}
