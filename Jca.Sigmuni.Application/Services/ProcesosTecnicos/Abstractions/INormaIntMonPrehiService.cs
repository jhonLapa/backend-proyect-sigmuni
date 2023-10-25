using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface INormaIntMonPrehiService
    {
        Task<int> CrearOActualizarAsync(NormaIntMonPrehiDto peticion);
        Task<bool> EliminarPorIdMonumentoPreinspanicoAsync(int? idMonumentoPre);
    }
}
