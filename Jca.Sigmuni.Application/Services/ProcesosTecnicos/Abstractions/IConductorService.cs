using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IConductorService
    {
        Task<int> GuardarPersonaConductorAsync(ConductorDto peticion);
    }
}
