using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.General.Abstractions
{
    public interface IUbigeoService
    {
        Task<IList<UbigeoDto>> FindAll();
        Task<ResponsePagination<UbigeoDto>> PaginatedSearch(RequestPagination<UbigeoDto> dto);
        Task<IList<UbigeoDto>> listarPorCodigo(string codigo);
    }
}
