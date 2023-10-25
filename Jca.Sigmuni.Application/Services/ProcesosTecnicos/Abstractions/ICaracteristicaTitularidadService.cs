using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ICaracteristicaTitularidadService
    {
        Task<CaracteristicaTitularidad?> CrearOActualizarAsync(CaracteristicaTitularidadDto peticion);
        Task<bool> EliminarAsync(int idCaracteristicaTitularidad);
    }
}
