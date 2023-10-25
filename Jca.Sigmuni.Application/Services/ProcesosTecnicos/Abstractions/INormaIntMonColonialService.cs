using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface INormaIntMonColonialService
    {
        //Task<int> CrearAsync(NormaIntMonColonialDto peticion);
        Task<int> CrearOActualizarAsync(NormaIntMonColonialDto peticion);
        Task<bool> EliminarPorIdMonumentoColonialAsync(int idMonumentoColonial);
    }
}
