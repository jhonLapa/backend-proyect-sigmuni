using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface ITitularCatastralService
    {
        Task<TitularCatastral?> CrearCotitularAsync(PersonaTitularDto peticion);
        Task<bool> EliminarCotitularAsync(PersonaTitularDto peticion);
        Task<TitularCatastral?> GuardarPersonaTitularAsync(PersonaTitularDto peticion);
        Task<bool> EliminarTitularCatastralAsync(int idTitularCatsatral);
    }
}
