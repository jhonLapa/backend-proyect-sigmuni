using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IArancelService
    {
        Task<bool> CrearOActualizarAsync(ArancelDto peticion);
        Task<bool> CrearMasivoAsync(List<ArancelDto> lista);
        Task<bool> EliminarAsync(int id);
        Task<List<ArancelDto>> FindAll();
        
        Task<ArancelDto> ObtenerAsync(int id);
        Task<ResponsePagination<ArancelDto>> PaginatedSearch(RequestPagination<ArancelDto> dto);
    }
}
