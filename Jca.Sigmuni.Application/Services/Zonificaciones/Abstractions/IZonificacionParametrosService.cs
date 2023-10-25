using Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.Zonificaciones.Abstractions
{
    public interface IZonificacionParametrosService
    {
        Task<IList<ZonificacionParametroDto>> FindAll();
        Task<ResponsePagination<ZonificacionParametroDto>> PaginatedSearch(RequestPagination<ZonificacionParametroDto> dto);
    }
}
