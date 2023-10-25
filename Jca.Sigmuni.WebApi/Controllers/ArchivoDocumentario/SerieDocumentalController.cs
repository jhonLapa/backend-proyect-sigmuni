using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]

    public class SerieDocumentalController : ControllerBase
    {
        private readonly ILogger<SerieDocumentalController> _logger;
        private readonly ISerieDocumentalService _serieDocumentalService;
        public SerieDocumentalController(ILogger<SerieDocumentalController> logger, ISerieDocumentalService serieDocumentalService)
        {
            _logger = logger;
            _serieDocumentalService = serieDocumentalService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<SerieDocumentalDto>> Get()
        => await _serieDocumentalService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SerieDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<SerieDocumentalDto>>> Get(int id)
        {
            var response = await _serieDocumentalService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SerieDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<SerieDocumentalDto>>> Post([FromBody] SerieDocumentalFormDto request)
        {
            var response = await _serieDocumentalService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SerieDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<SerieDocumentalDto>>> Put(int id, [FromBody] SerieDocumentalFormDto request)
        {
            var response = await _serieDocumentalService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<SerieDocumentalDto>> PaginatedSearch([FromQuery] RequestPagination<SerieDocumentalDto> request)
        => await _serieDocumentalService.PaginatedSearch(request);
    }
}
