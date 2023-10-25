using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ICategoriaConstruccionRepository
    {
        Task<IList<CategoriaConstruccion>> FindAll();
        Task<CategoriaConstruccion?> ObtenerPorCodigoAsync(string codigo);
    }
}
