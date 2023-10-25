using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IUnidadMedidaService
    {
        Task<IList<UnidadMedidaDto>> FindAll();
    }
}
