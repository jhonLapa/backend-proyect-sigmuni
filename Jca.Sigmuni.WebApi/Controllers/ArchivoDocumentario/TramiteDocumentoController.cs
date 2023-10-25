using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TramiteDocumentoController : ControllerBase
    {
        private readonly ILogger<TramiteDocumentoController> _logger;
        private readonly ITramiteDocumentoService _tramiteDocumentoService;

        public TramiteDocumentoController(ILogger<TramiteDocumentoController> logger, ITramiteDocumentoService tramiteDocumentoService)
        {
            _logger = logger;
            _tramiteDocumentoService = tramiteDocumentoService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<TramiteDocumentoDto>> Get()
        => await _tramiteDocumentoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TramiteDocumentoDto>>> Get(int id)
        {
            var response = await _tramiteDocumentoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TramiteDocumentoDto>>> Post([FromBody] TramiteDocumentoFormDto request)
        {
            var response = await _tramiteDocumentoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<TramiteDocumentoDto>>> Put(int id, [FromBody] TramiteDocumentoFormDto request)
        {
            var response = await _tramiteDocumentoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TramiteDocumentoDto>>> Delete(int id)
        {
            var response = await _tramiteDocumentoService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<TramiteDocumentoDto>> PaginatedSearch([FromQuery] RequestPagination<TramiteDocumentoDto> request)
        => await _tramiteDocumentoService.PaginatedSearch(request);


        //[RequiereAcceso()]
        [HttpPost("CrearMasivo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TramiteDocumentoDto>>> PostMasivo([FromBody] List<TramiteDocumentoPFormDto> request)
        {
            var response = await _tramiteDocumentoService.CrearOActualizarActualizadoAsync(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpGet("ObtenerMasivo/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TramiteDocumentoObtenerDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<List<TramiteDocumentoDto>>>> GetMasivo(int id)
        {
            var response = await _tramiteDocumentoService.ObtenerPorIdAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response.TramiteDocumentos);
        }


        [HttpGet("ObtenerUltimoNumeroTramiteDo")]
        public async Task<TramiteDocumentoDto> ObtenerUltimoNumeroTramiteDo()
        => await _tramiteDocumentoService.ObtenerUltimoNumeroTramiteDo();

    }
}
