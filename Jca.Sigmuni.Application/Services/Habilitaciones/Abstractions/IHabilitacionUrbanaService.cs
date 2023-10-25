using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions
{
    public interface IHabilitacionUrbanaService
    {
        Task<IList<HabilitacionUrbanaDto>> FindAll();
        Task<ResponsePagination<HabilitacionUrbanaDto>> PaginatedSearch(RequestPagination<HabilitacionUrbanaBusquedaDto> dto);
    }
}
