using Jca.Sigmuni.Application.Dtos.General.SeccionDocumentals;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeccionDocumentalController : ControllerBase
    {
        private readonly ILogger<SeccionDocumentalController> _logger;
        private readonly ISeccionDocumentoService _seccionDocumentoService;

        public SeccionDocumentalController(ILogger<SeccionDocumentalController> logger, ISeccionDocumentoService seccionDocumentoService)
        {
            _logger = logger;
            _seccionDocumentoService = seccionDocumentoService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<SeccionDocumentalDto>> Get()
        => await _seccionDocumentoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeccionDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<SeccionDocumentalDto>>> Get(int id)
        {
            var response = await _seccionDocumentoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeccionDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<SeccionDocumentalDto>>> Post([FromBody] SeccionDocumentalFormDto request)
        {
            var response = await _seccionDocumentoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SeccionDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<SeccionDocumentalDto>>> Put(int id, [FromBody] SeccionDocumentalFormDto request)
        {
            var response = await _seccionDocumentoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<SeccionDocumentalDto>> PaginatedSearch([FromQuery] RequestPagination<SeccionDocumentalDto> request)
        => await _seccionDocumentoService.PaginatedSearch(request);

    }
}
