using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.WebApi.Controllers.General;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/[controller]")]
    [ApiController]
    public class FichaController : ControllerBase
    {
        private readonly ILogger<FichaController> _logger;
        private readonly IFichaService _fichaService;

        public FichaController(ILogger<FichaController> logger, IFichaService fichaService)
        {
            _logger = logger;
            _fichaService = fichaService;
        }

        [HttpPost("GuardarFichaIndividual")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IndividualFormDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<IndividualDto>>> Post([FromBody] IndividualFormDto request)
        {
            var operacion = await _fichaService.GuardarFichaIndividualAsync(request);

            var operacionRespuesta = await _fichaService.FichaIndividualPorIdAsync(operacion);

            if (operacionRespuesta == null) return TypedResults.BadRequest();   

            return TypedResults.Ok(operacionRespuesta);
        }

        [HttpPost("CrearFichaCotitularNuevo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FichaCotitularFormDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<FichaCotitularDto>>> Post([FromBody] FichaCotitularFormDto request)
        {

            var operacion = await _fichaService.GuardarFichaCotitularAsync(request);

            var operacionRespuesta = await _fichaService.FindFichaCotitularByIdAsync(operacion);
            if (operacionRespuesta == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacionRespuesta);
        }

        [HttpGet("FichaCotitularPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FichaCotitularDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<FichaCotitularDto>>> GetCotitular(int id)
        {
            var response = await _fichaService.FindFichaCotitularByIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("GuadarFichaBienComun")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BienComunFormDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<BienComunDto>>> Post([FromBody] BienComunFormDto request)
        {
            var operacion = await _fichaService.GuardarFichaBienComunAsync(request);

            var operacionRespuesta = await _fichaService.FichaBienComunPorIdAsync(operacion);

            if (operacionRespuesta == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacionRespuesta);
        }

        [HttpPost("FichaBienComunPorTBLCodigoAsync")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BienCommunPeticionDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<BienComunDto>>> Post([FromBody] BienCommunPeticionDto request)
        {
            var operacion = await _fichaService.FichaBienComunPorTBLCodigodAsync(request);

            if (operacion == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }

        [HttpGet("FichaIndividualPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IndividualDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<IndividualDto>>> FichaIndividualPorId(int id)
        {
            var response = await _fichaService.FichaIndividualPorIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("FichaBienComunPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BienComunDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<BienComunDto>>> FichaBienComunPorId(int id)
        {
            var response = await _fichaService.FichaBienComunPorIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("CrearFichaBienCultural")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BienCulturalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<BienCulturalDto>>> Post([FromBody] BienCulturalDto request)
        {
            var operacion = await _fichaService.GuardarFichaBienCultural2Async(request);
           
            var operacionRespuesta = await _fichaService.FindFichaBienCulturalByIdAsync(operacion);

            if (operacionRespuesta == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacionRespuesta);
        }

        [HttpGet("FichaBienCulturalPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(BienCulturalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<BienCulturalDto>>> GetBienCultural(int id)
        {
            var response = await _fichaService.FindFichaBienCulturalByIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("CrearActividadEconomica")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActividadEconomicaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ActividadEconomicaDto>>> Post([FromBody] ActividadEconomicaDto request)
        {
            var operacion = await _fichaService.GuardarFichaActividadEconomica2Async(request);
            var operacionRespuesta = await _fichaService.FindFichaActividadEconomicaByIdAsync(operacion);

            if (operacionRespuesta == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacionRespuesta);
        }

        [HttpPost("FichasActividadesEconomicasPorId")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActividadEconomicaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<List<ActividadEconomicaDto>>>> GetActividadesEconomicas(List<int> listaIds)
        {
            var response = await _fichaService.FindFichasActividadesEconomicasByIdAsync(listaIds);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("FichaActividadEconomicPorId/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ActividadEconomicaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ActividadEconomicaDto>>> GetActividadEconomica(int id)
        {
            var response = await _fichaService.FindFichaActividadEconomicaByIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("IdsFichasEconomicasAsociadasPorId/{id}")]
        public async Task<List<int>> IdsFichasEconomicasAsociadasPorId(int id)
        {
            return await _fichaService.ListaIdsFichasEconomicasPorIdFichaIndividual(id);
        }

        [HttpGet("SelectPaginatedSearch")]
        public async Task<ResponsePagination<FichaBusquedaDto>> SelectPaginatedSearch([FromQuery]RequestPagination<FichaBusquedaDto>request)
            => await _fichaService.SelectPaginatedSearch(request);
    }
}
