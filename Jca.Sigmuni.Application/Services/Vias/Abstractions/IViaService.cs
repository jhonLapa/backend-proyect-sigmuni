using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.Vias.Abstractions
{
    public interface IViaService
    {
        Task<IList<ViaDto>> FindAll();
        Task<ResponsePagination<ViaDto>> PaginatedSearch(RequestPagination<ViaBusquedaDto> dto);
    }
}
