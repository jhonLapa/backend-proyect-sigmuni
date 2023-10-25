using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface ICategoriaRangoService 
    {
        Task<CategoriaRangoDto> CrearOActualizar(CategoriaRangoConsultarDto peticion);
        Task<ResponsePagination<CategoriaRangoDto>> PaginatedSearch(RequestPagination<CategoriaRangoDto> dto);
        Task<IList<CategoriaRangoDto>> FindAll();
        Task<CategoriaRangoConsultarDto> ObtenerRangoyCategoria(int id, int anio);
        Task<CategoriaRangoDto?> Disable(int id);

    }
}
