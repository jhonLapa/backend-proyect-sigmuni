using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoDeclaratoriaRepository
    {
        Task<IList<TipoDeclaratoria>> FindAll();
        Task<TipoDeclaratoria?> BuscarPorCodigoAsync(string codigo);
    }
}
