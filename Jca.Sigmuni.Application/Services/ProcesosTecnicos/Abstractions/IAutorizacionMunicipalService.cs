using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IAutorizacionMunicipalService
    {
        Task<int> CrearAsync(AutorizacionMunicipalDto peticion);
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
    }
}
