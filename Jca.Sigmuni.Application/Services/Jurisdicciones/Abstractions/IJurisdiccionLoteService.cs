using Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.Jurisdicciones.Abstractions
{
    public interface IJurisdiccionLoteService
    {
        Task<IList<JurisdiccionLoteDto>> FindAll();
        Task<ResponsePagination<JurisdiccionLoteDto>> PaginatedSearch(RequestPagination<JurisdiccionLoteDto> dto);
    }
}
