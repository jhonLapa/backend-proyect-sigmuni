using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaRangoController : ControllerBase
    {
        private readonly ILogger<CategoriaRangoController> _logger;
        private readonly ICategoriaRangoService _categoriaRangoService;

        public CategoriaRangoController(ILogger<CategoriaRangoController> logger, ICategoriaRangoService CategoriaRangoService)
        {
            _logger = logger;
            _categoriaRangoService = CategoriaRangoService;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoriaRangoDto>> Get()
        => await _categoriaRangoService.FindAll();

        //[AllowAnonymous]
        [HttpGet("PaginatedSearch")]
         public async Task<ResponsePagination<CategoriaRangoDto>> PaginatedSearch([FromQuery] RequestPagination<CategoriaRangoDto> request)
         => await _categoriaRangoService.PaginatedSearch(request);

        //[AllowAnonymous]

        [HttpPost("CrearOActualizar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaRangoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<CategoriaRangoDto>>> CrearOActualizar([FromBody] CategoriaRangoConsultarDto request)
        {
            var response = await _categoriaRangoService.CrearOActualizar(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        //[AllowAnonymous]


        [HttpGet("ObtenerRangoyCategoria/{id}/{anio}")]
        public async Task<CategoriaRangoConsultarDto> ObtenerRangoyCategoria(int id, int anio)
        {
            var response = await _categoriaRangoService.ObtenerRangoyCategoria(id, anio);
            return response;
        }
        //[AllowAnonymous]


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(CategoriaRangoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<CategoriaRangoDto>>> Delete(int id)
        {
            var response = await _categoriaRangoService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

    }
}
