using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfDocumentoController : ControllerBase
    {
        private readonly ILogger<InfDocumentoController> _logger;
        private readonly IInfDocumentoService _infDocumentoService;
        private readonly IInfDocumentoSPService _infDocumentoSPService;
        private readonly IInfDocumentoSPService infDocumentoSPService1;


        public InfDocumentoController(ILogger<InfDocumentoController> logger, IInfDocumentoService infDocumentoService, IInfDocumentoSPService infDocumentoSPService, IInfDocumentoSPService infDocumentoSPService1)
        {
            _logger = logger;
            _infDocumentoService = infDocumentoService;
            _infDocumentoSPService = infDocumentoSPService;
            this.infDocumentoSPService1 = infDocumentoSPService1;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<InfDocumentoDto>> Get()
        => await _infDocumentoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InfDocumentoDto>>> Get(int id)
        {
            var response = await _infDocumentoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<InfDocumentoDto>>> Post([FromBody] InfDocumentoFormDto request)
        {
            var response = await _infDocumentoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<InfDocumentoDto>>> Put(int id, [FromBody] InfDocumentoFormDto request)
        {
            var response = await _infDocumentoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InfDocumentoDto>> PaginatedSearch([FromQuery] RequestPagination<InfDocumentoDto> request)
        => await _infDocumentoService.PaginatedSearch(request);

        [HttpGet("PaginatedPrestamoSearch")]
        public async Task<ResponsePagination<InfDocumentoSPDto>> PaginatedPrestamoSearch([FromQuery] RequestPagination<InfDocumentoSPDto> request)
        => await _infDocumentoSPService.PaginatedSearch(request);

        [AllowAnonymous]

        [HttpGet("ObtenerUltimoNumeroInf")]
        public async Task<InfDocumentoDto> ObtenerUltimoNumeroInf()
         => await _infDocumentoService.ObtenerUltimoNumeroInf();

        [HttpGet("Obtener/{numeroExpediente}/{anio}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfDocumentoSPDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InfDocumentoSPDto>>> GetDetalle(string numeroExpediente, string anio)
        {
            var response = await infDocumentoSPService1.ListarDetalleAsync(numeroExpediente, anio);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

    }
}
