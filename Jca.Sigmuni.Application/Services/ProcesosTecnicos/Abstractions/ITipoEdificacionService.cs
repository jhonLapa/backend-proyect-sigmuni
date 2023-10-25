using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEdificaciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoEdificacionService
    {
        Task<IList<TipoEdificacionDto>> FindAll();
    }
}
