using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IDepreciacionService
    {
        Task<DepreciacionDto> ObtenerAsync(int id);
        Task<List<DepreciacionDto>> ListarGlobalAsync();
        Task<List<DepreciacionDto>> ListarFiltroAsync(DepreciacionDto peticion);
        Task<bool> CrearOActualizarAsync(DepreciacionDto peticion);
        Task<bool> EliminarAsync(int id);
        Task<ResponsePagination<DepreciacionDto>> PaginatedSearch(RequestPagination<DepreciacionDto> dto);
    }
}
