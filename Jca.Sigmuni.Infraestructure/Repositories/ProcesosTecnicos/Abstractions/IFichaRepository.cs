using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Core.Repositories;
using Jca.Sigmuni.Util.Flags;

namespace Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions
{
    public interface IFichaRepository : IRepositoryCrud<Ficha, int>, IRepositoryPaginated<Ficha>
    {
        //Ficha Individual
        Task<Ficha?> ObtenerPorIdUnidadEstadoFichaIdTipoAsync(int idUnidadCatastral, EstadoFicha estadoFicha, TipoFichaEnum tipoFicha);
        Task<List<Ficha>> BuscarPorIdLoteCartoYIdTipoAsync(string idLoteCartografia, int idTipo);
        Task<Ficha?> FindByIdAsync(int id);
        Task<List<Ficha>> BuscarPorIdFichaPadreYEstadoFichaAsync(int? idFichaPadre, int estadoFicha);
        //Cotitular
        Task<Ficha?> FindCotitularByIdAsync(int id);
        //Economica
        Task<Ficha?> FindFichaActividadEconomicaByIdAsync(int idFicha);
        //Cultural
        Task<Ficha?> FindFichaBienCulturalByIdAsync(int id);
        //Comun
        Task<Ficha?> FindBienComunByIdAsync(int id);
        Task<Ficha> ObtenerPorIdUnidadAnioFichaIdTipoAsync(int idUnidadCatastral, EstadoFicha estadoFicha, int? anioFicha, TipoFichaEnum tipoFicha);
        Task<ResponsePagination<FichaBusqueda>>SelectPaginatedSearch(RequestPagination<FichaBusqueda> entity);

        Task<List<Ficha>> BuscarPorIdUnidadCatrastalAsync(int idUnidadCatrastal);
        Task<ResponsePagination<AnioReporte>> ListarAniosValorizacionAsync(RequestPagination<AnioReporte> entity);

        Task<ResponsePagination<Ficha>> PaginatedSearchValorizacion(RequestPagination<ValorizacionBusqueda> entity);
        Task<List<Ficha>> SearchValorizacion(ValorizacionBusqueda entity);
    }
}
