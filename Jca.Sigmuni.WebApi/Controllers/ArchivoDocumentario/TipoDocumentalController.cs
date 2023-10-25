using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentalController : ControllerBase
    {
        private readonly ILogger<TipoDocumentalController> _logger;
        private readonly ITipoDocumentalService _tipoDocumentalService;
        public TipoDocumentalController(ILogger<TipoDocumentalController> logger, ITipoDocumentalService tipoDocumentalService)
        {
            _logger = logger;
            _tipoDocumentalService = tipoDocumentalService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<TipoDocumentalDto>> Get()
        => await _tipoDocumentalService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoDocumentalDto>>> Get(int id)
        {
            var response = await _tipoDocumentalService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TipoDocumentalDto>>> Post([FromBody] TipoDocumentalFormDto request)
        {
            var response = await _tipoDocumentalService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<TipoDocumentalDto>>> Put(int id, [FromBody] TipoDocumentalFormDto request)
        {
            var response = await _tipoDocumentalService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<TipoDocumentalDto>> PaginatedSearch([FromQuery] RequestPagination<TipoDocumentalDto> request)
        => await _tipoDocumentalService.PaginatedSearch(request);
    }
}
