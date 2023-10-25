using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesVerificadas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IActividadVerificadaService
    {
        Task<IList<ActividadVerificadaDto>> FindAll();
    }
}
