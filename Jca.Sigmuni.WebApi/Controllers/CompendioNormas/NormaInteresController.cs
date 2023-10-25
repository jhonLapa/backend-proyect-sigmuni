using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Dtos.General.Documentos;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Services.CompendioNormas.Abstractions;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.WebApi.Controllers.General;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.CompendioNormas
{
    [Route("api/[controller]")]
    [ApiController]
    public class NormaInteresController : ControllerBase
    {
        private readonly ILogger<NormaInteresController> _logger;
        private readonly INormaInteresService _normaInteresService;
        private readonly INormaInteresMenuService _normaInteresMenuService;
        private readonly IDocumentoService _documentoService;


        public NormaInteresController(ILogger<NormaInteresController> logger, INormaInteresService normaInteresService, INormaInteresMenuService normaInteresMenuService, IDocumentoService documentoService)
        {
            _logger = logger;
            _normaInteresService = normaInteresService;
            _normaInteresMenuService = normaInteresMenuService;
            _documentoService = documentoService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<NormaInteresDto>> Get()
        => await _normaInteresService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<NormaInteresDto>>> Get(int id)
        {
            var response = await _normaInteresService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("obtenerDetalleNorma/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaDiaDetalleDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<NormaDiaDetalleDto>>> GetDetalleNorma(int id)
        {
            var response = await _normaInteresService.FindNormaDetalleAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<NormaInteresDto>>> Post([FromBody] NormaInteresFormDto request)
        {
            var response = await _normaInteresService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<NormaInteresDto>>> Put(int id, [FromBody] NormaInteresFormDto request)
        {
            var response = await _normaInteresService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<NormaInteresDto>> PaginatedSearch([FromQuery] RequestPagination<NormaInteresDto> request)
        => await _normaInteresService.PaginatedSearch(request);


        [HttpPost("CrearNormaMenu")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresMenuDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<NormaInteresMenuDto>>> PostNormaMenu([FromBody] NormaInteresMenuFormDto request)
        {
            var response = await _normaInteresMenuService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpGet("obtenerNormaMenu/{id}")]
        public async Task<IEnumerable<NormaInteresMenuDto>> GetNormaMenu(int id)
        => await _normaInteresMenuService.BuscarPorIdNormaInteres(id);

        [HttpPost("CrearNormaDocumento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<NormaInteresDto>>> PostNormaDocumento([FromBody] NormaInteresDocumentoDto request)
        {
            if (request.Documento != null)
            {
                var responseDocumento = await _documentoService.Create(request.Documento);
                request.IdDocumento = responseDocumento.IdDocumentoB64;
            }
            var id = request.IdNormaInteres;
            var normaInteres = new NormaInteresFormDto();
            normaInteres.PaginasInteres = request.PaginasInteres;
            normaInteres.Observacion = request.Observacion;
            normaInteres.ArticuloNormaDerogado = request.ArticuloNormaDerogado;
            normaInteres.ObservacionNormaDerogado = request.ObservacionNormaDerogado;
            normaInteres.IdNormaDiaDetalle = request.IdNormaDiaDetalle;
            normaInteres.IdDocumento = request.IdDocumento;
            normaInteres.IdUsuario = request.IdUsuario;
            normaInteres.IdTipoNorma = request.IdTipoNorma;
            normaInteres.IdNaturaleza = request.IdNaturaleza;
            normaInteres.IdAutoridad = request.IdAutoridad;
            normaInteres.IdEstadoNorma = request.IdEstadoNorma;
            normaInteres.Nombre = request.Nombre;
            normaInteres.Sumilla = request.Sumilla;
            normaInteres.IdTipoNorma = request.IdTipoNorma;
            normaInteres.NormaDiaDetalle = request.NormaDiaDetalle;

            var response = await _normaInteresService.Edit(id,normaInteres);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpDelete("DeleteMenuNorma/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NormaInteresMenuDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<NormaInteresMenuDto>>> Delete(int id)
        {
            var response = await _normaInteresMenuService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
