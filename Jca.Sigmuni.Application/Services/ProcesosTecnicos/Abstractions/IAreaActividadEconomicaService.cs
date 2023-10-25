using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IAreaActividadEconomicaService
    {
        Task<int> CrearOActualizarAsync(AreaActividadEconomicaDto peticion);
    }
}
