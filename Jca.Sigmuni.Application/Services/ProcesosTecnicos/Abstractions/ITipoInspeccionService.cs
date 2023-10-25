using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoInspeccionService
    {
        Task<IList<TipoInspeccionDto>> FindAll();
    }
}
