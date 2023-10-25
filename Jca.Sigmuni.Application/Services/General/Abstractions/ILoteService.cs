using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface ILoteService 
    {
        Task<IList<LoteDto>> FindAll();
        Task<ResponsePagination<LoteDto>> PaginatedSearch(RequestPagination<LoteFormDto> dto);
        Task<LoteDetalleDto> ObtenerDatosPorLote(string idLoteCarto);
        Task<LoteDto?> Find(string id);
    }
}
