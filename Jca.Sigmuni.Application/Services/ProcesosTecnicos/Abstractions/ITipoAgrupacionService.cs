using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAgrupaciones;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITipoAgrupacionService
    {
        Task<IList<TipoAgrupacionDto>> FindAll();
    }
}
