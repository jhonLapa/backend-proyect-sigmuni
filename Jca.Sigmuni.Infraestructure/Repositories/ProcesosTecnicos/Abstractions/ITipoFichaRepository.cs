using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoFichaRepository
    {
        Task<IList<TipoFicha>> FindAll();
    }
}
