using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IAutorizacionAnuncioService
    {
        Task<int> CrearAsync(AutorizacionAnuncioDto peticion);
        Task<bool> EliminarPorIdFichaAsync(int idFicha);
    }
}
