using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions
{
    public interface IZonificacionRepository : IRepositoryCrud<ZonificacionParametro, int>
    {
        Task<ResponsePagination<ZonificacionParametro>> PaginatedSearch(RequestPagination<ZonificacionParametro> entity);
    }
}
