using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentoIdentidadController : ControllerBase
    {
        private readonly ILogger<TipoPersonaController> _logger;
        private readonly IDocumentoIdentidadService _documentoIdentidadService;

        public DocumentoIdentidadController(ILogger<TipoPersonaController> logger, IDocumentoIdentidadService documentoIdentidadService)
        {
            _logger = logger;
            _documentoIdentidadService = documentoIdentidadService;
        }


        [HttpGet]
        public async Task<IEnumerable<DocumentoIdentidadDto>> Get()
        => await _documentoIdentidadService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoIdentidadDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DocumentoIdentidadDto>>> Get(int id)
        {
            var response = await _documentoIdentidadService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoIdentidadDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<DocumentoIdentidadDto>>> Post([FromBody] DocumentoIdentidadFormDto request)
        {
            var response = await _documentoIdentidadService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoIdentidadDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<DocumentoIdentidadDto>>> Put(int id, [FromBody] DocumentoIdentidadFormDto request)
        {
            var response = await _documentoIdentidadService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoIdentidadDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DocumentoIdentidadDto>>> Delete(int id)
        {
            var response = await _documentoIdentidadService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<DocumentoIdentidadDto>> PaginatedSearch([FromQuery] RequestPagination<DocumentoIdentidadDto> request)
        => await _documentoIdentidadService.PaginatedSearch(request);
    }
}
