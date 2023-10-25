using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IMonumentoColonialService
    {
        Task<int?> CrearOActualizarAsync(MonumentoColonialDto peticion);
        
    }
}
