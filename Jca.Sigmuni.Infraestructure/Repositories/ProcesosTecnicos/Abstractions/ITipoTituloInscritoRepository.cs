using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoTituloInscritoRepository
    {
        Task<IList<TipoTituloInscrito>> FindAll();
        Task<TipoTituloInscrito?> BuscarPorCodigoAsync(string codigo);
    }
}
