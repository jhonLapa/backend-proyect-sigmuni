using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoMantenimientoService
    {
        Task<IList<TipoMantenimientoDto>> FindAll();
    }
}
