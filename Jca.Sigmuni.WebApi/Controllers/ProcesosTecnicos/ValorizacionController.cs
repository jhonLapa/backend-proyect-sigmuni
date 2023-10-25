using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ValorizacionController : ControllerBase
    {
        private readonly IValorizacionService _valorizacionService;

        public ValorizacionController(
                                    IValorizacionService valorizacionService
                                    )
        {
            _valorizacionService = valorizacionService;
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ValorizacionBusquedaDto>> PaginatedSearch([FromQuery] RequestPagination<ValorizacionBusquedaDto> request)
            => await _valorizacionService.PaginatedSearch(request);

        [HttpGet("ListarPorFiltro")]
        public async Task<List<ValorizacionBusquedaDto>> ListarPorFiltro([FromQuery] ValorizacionBusquedaDto request)
            => await _valorizacionService.ListarPorFiltro(request);

        [HttpGet("ListarAniosValorizacionAsync")]
        public async Task<ResponsePagination<AnioReporteDto>> ListarAniosValorizacionAsync([FromQuery] RequestPagination<AnioReporteDto> request)
            => await _valorizacionService.ListarAniosValorizacionAsync(request);

        [HttpGet("ObtenerValorizacion/{idFicha}")]
        public async Task<ValorizacionDetalleDto> ObtenerValorizacionAsync(int idFicha)
            => await _valorizacionService.ObtenerDetalleValorizacionPorIdFichaAsync(idFicha);

        [HttpPost("ListarReportePorAnio")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AnioReporteDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<List<ValorizacionBusquedaDto>>>> Post([FromBody] List<AnioReporteDto> request)
        {
            var operacion = await _valorizacionService.ListarUnidadesValorizacionReporteAniosAsync(request);

            if (operacion == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }
    }
}
