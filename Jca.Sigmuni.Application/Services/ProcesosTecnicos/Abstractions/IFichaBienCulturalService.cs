using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IFichaBienCulturalService
    {
        Task<int> CrearOActualizarAsync(FichaBienCulturalDto peticion);
    }
}
