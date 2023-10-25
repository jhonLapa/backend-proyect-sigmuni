using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface ITipoMantenimientoRepository
    {
        Task<IList<TipoMantenimiento>> FindAll();
        Task<TipoMantenimiento> BuscarPorCodigoAsync(string codigo);
    }
}
