using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        private readonly ILoteService _loteService;

        public LoteController(ILoteService loteService)
        {
            _loteService = loteService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<LoteDto>>> Get(string id)
        {
            var response = await _loteService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet]
        public async Task<IEnumerable<LoteDto>> FindAll()
       => await _loteService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<LoteDto>> PaginatedSearch([FromQuery] RequestPagination<LoteFormDto> request)
         => await _loteService.PaginatedSearch(request);

        //[HttpGet("ObtenerDatos/{idLoteCarto}")]
        //public async Task<LoteCabeceraDto> ObtenerDatosPorLote(string idLoteCarto)
        //{
        //    var operacion = await _loteBusquedaServicio.ObtenerCabeceraPorLote(idLoteCarto);
        //    return ObtenerResultadoOGenerarErrorDeOperacion(operacion);
        //}
        [AllowAnonymous]
        [HttpGet("ObtenerDatos/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<LoteDetalleDto>>> ObtenerDatosPorLote(string id)
        {
            var response = await _loteService.ObtenerDatosPorLote(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
