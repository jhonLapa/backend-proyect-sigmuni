using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IDepreciacionRepository : IRepositoryBase<Depreciacion, int>
    {
        Task<Depreciacion?> Edit(int id, Depreciacion entity);
        Task<Depreciacion> BuscarPorClasificacionEstadoAntiguedad(int idClasificacion, int idAntiguedad, int idMep, int idEcs);
        Task<List<Depreciacion>> ListarPorFiltro(bool estado, int? idClasificacion, int? idAntiguedad, int? idMep, int? idEcs, decimal? porcentaje);
        Task<Depreciacion> ObtenerDepreciacionCalculo(int idClasificacionPredio, int? idMep, int? idEcs, int aniosCostruccion);
        Task<ResponsePagination<Depreciacion>> PaginatedSearch(RequestPagination<Depreciacion> entity);
    }
}
