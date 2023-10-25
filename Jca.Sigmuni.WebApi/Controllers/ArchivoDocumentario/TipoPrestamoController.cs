using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoPrestamo;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoPrestamoController : ControllerBase
    {
        private readonly ILogger<TipoPrestamoController> _logger;
        private readonly ITipoPrestamoService _tipoPrestamoService;

        public TipoPrestamoController(ILogger<TipoPrestamoController> logger, ITipoPrestamoService tipoPrestamoService)
        {
            _logger = logger;
            _tipoPrestamoService = tipoPrestamoService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<TipoPrestamoDto>> Get()
        => await _tipoPrestamoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPrestamoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoPrestamoDto>>> Get(int id)
        {
            var response = await _tipoPrestamoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPrestamoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TipoPrestamoDto>>> Post([FromBody] TipoPrestamoFormDto request)
        {
            var response = await _tipoPrestamoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPrestamoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<TipoPrestamoDto>>> Put(int id, [FromBody] TipoPrestamoFormDto request)
        {
            var response = await _tipoPrestamoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
