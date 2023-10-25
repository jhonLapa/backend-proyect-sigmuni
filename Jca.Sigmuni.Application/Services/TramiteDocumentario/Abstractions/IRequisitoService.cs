using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IRequisitoService
    {
        Task<IList<RequisitoDto>> FindAll();
        Task<ResponsePagination<RequisitoDto>> PaginatedSearch(RequestPagination<RequisitoDto> dto);
        Task<RequisitoDto?> Find(int id);
        Task<RequisitoDto?> Disable(int id);
        Task<RequisitoDto> Create(RequisitoFormDto dto);
        Task<RequisitoDto?> Edit(int id, RequisitoFormDto dto);
    }
}
