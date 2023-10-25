using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubSerieDocumentalController : ControllerBase
    {
        private readonly ILogger<SubSerieDocumentalController> _logger;
        private readonly ISubSerieDocumentalService _subSerieDocumentalService;

        public SubSerieDocumentalController(ILogger<SubSerieDocumentalController> logger, ISubSerieDocumentalService subSerieDocumentalService)
        {
            _logger = logger;
            _subSerieDocumentalService = subSerieDocumentalService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<SubSerieDocumentalDto>> Get()
        => await _subSerieDocumentalService.FindAll();


        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubSerieDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<SubSerieDocumentalDto>>> Get(int id)
        {
            var response = await _subSerieDocumentalService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SubSerieDocumentalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<SubSerieDocumentalDto>>> Put(int id, [FromBody] SubSerieDocumentalFormDto request)
        {
            var response = await _subSerieDocumentalService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<SubSerieDocumentalDto>> PaginatedSearch([FromQuery] RequestPagination<SubSerieDocumentalDto> request)
        => await _subSerieDocumentalService.PaginatedSearch(request);
    }
}
