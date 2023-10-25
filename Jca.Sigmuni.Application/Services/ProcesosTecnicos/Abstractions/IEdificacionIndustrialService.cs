using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IEdificacionIndustrialService
    {
        Task<IList<EdificacionIndustrialDto>> FindAll();
    }
}
