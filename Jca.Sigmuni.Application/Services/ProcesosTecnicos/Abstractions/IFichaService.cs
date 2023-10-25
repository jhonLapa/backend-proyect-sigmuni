using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions
{
    public interface IFichaService
    {

        //Ficha Individual
        Task<int> GuardarFichaIndividualAsync(IndividualFormDto peticion);
        Task<IndividualDto> FichaIndividualPorIdAsync(int idFicha);
        //Ficha Cotitular
        Task<FichaCotitularDto> FindFichaCotitularByIdAsync(int idFicha);
        Task<int> GuardarFichaCotitularAsync(FichaCotitularFormDto peticion);
        //Ficha Actividad Economica
        Task<List<ActividadEconomicaDto>> FindFichasActividadesEconomicasByIdAsync(List<int> idFicha);
        Task<List<int>> ListaIdsFichasEconomicasPorIdFichaIndividual(int idFicha);
        Task<ActividadEconomicaDto> FindFichaActividadEconomicaByIdAsync(int idFicha);
        Task<int> GuardarFichaActividadEconomica2Async(ActividadEconomicaDto peticion);
        //Ficha Bien Comun
        Task<int> GuardarFichaBienComunAsync(BienComunFormDto peticion); 
        Task<BienComunDto> FichaBienComunPorIdAsync(int idFicha);
        Task<BienComunDto> FichaBienComunPorTBLCodigodAsync(BienCommunPeticionDto peticion);
        //Ficha Bien Cultural
        Task<BienCulturalDto> FindFichaBienCulturalByIdAsync(int idFicha);
        Task<int> GuardarFichaBienCultural2Async(BienCulturalDto peticion);
        Task<ResponsePagination<FichaBusquedaDto>> SelectPaginatedSearch(RequestPagination<FichaBusquedaDto> dto);













    }
}
