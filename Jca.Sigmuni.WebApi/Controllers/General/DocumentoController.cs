using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
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
    public class DocumentoController : ControllerBase
    {
        private readonly ILogger<DocumentoController> _logger;
        private readonly IDocumentoService _documentoService;

        public DocumentoController(ILogger<DocumentoController> logger, IDocumentoService documentoService)
        {
            _logger = logger;
            _documentoService = documentoService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<DocumentoB64Dto>> Get()
        => await _documentoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoB64Dto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DocumentoB64Dto>>> Get(int id)
        {
            var response = await _documentoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("obtenerFullDocumento/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DocumentoDto>>> GetFullDocumento(int id)
        {
            var response = await _documentoService.FindFullDocument(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoB64Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<DocumentoB64Dto>>> Post([FromBody] DocumentoB64FormDto request)
        {
            var response = await _documentoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DocumentoB64Dto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<DocumentoB64Dto>>> Put(int id, [FromBody] DocumentoB64FormDto request)
        {
            var response = await _documentoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
