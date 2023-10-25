using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IClasificacionPredioService
    {
        Task<IList<ClasificacionPredioDto>> FindAll();
    }
}
