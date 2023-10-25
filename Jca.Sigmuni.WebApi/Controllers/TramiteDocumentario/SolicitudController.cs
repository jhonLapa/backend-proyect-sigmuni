using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class SolicitudController : ControllerBase
    {
        private readonly ILogger<SolicitudController> _logger;
        private readonly ISolicitudService _solicitudService;
        public SolicitudController(ILogger<SolicitudController> logger, ISolicitudService solicitudService)
        {
            _logger = logger;
            _solicitudService = solicitudService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<SolicitudDto>> Get()
        => await _solicitudService.FindAll();

        [HttpGet("listarxInfoDocumento")]
        public async Task<IEnumerable<SolicitudDto>> GetSolInfo()
        => await _solicitudService.FindAllInfoDocumento();

        [HttpPost("CrearSolicitudPresencial")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolicitudDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<SolicitudDto>>> Post([FromBody] SolicitudFormDto request)
        {
            var respuesta = true;
            var response = await _solicitudService.CrearSolicitudPresencialAsunc(request);
            if (response == null)
            {
                respuesta = false;
                return TypedResults.BadRequest();
            }
            return TypedResults.Ok(response);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolicitudDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound,Ok<SolicitudDto>>>Get(int id)
        {
            var response = await _solicitudService.Find(id); if (response == null) return TypedResults.NotFound();
            return TypedResults.Ok(response);

        }



        [HttpGet("ObtenerTramiteSolicitud/{id}")]
        public async Task<SolicitudDto> ObtenerTramiteSolicitud(int id)
        {
            var response= await _solicitudService.ObtenerTramiteSolicitudPorIdAsyn(id);
            return response;
        }

        [HttpGet("PaginacionSolicitudes")]
        public async Task<ResponsePagination<SolicitudDto>> PaginacionSolicitud([FromQuery] RequestPagination<SolicitudDto>request)
            => await _solicitudService.PaginatedSearch(request);

        [HttpGet("ObtenerSolicitudPorNumeroSolicitud/{numeroSolicitud}")]
        public async Task<SolicitudDto>ObtenerSolicitudPorNumeroSolicitud(string numeroSolicitud)
        {
            var response = await _solicitudService.ObtenerPorNumeroSolicitud(numeroSolicitud);
            return response;
        }


        [AllowAnonymous]

        [HttpGet("ObtenerPorAnioSolicitud/{anio}")]
        public async Task<List<SolicitudDto>> ObtenerPorAnioSolicitud(int anio)
        {
            var response = await _solicitudService.ObtenerPorAnioSolicitud(anio);
            return response;
        }

        [HttpGet("obtenerUltimo")]
        public async Task<SolicitudDto>ObtenerUltimo()
            =>await _solicitudService.ObtenerUltimoSolicitud();

        [HttpGet("PaginacionBusquedaSolicitudes")]
        public async Task<ResponsePagination<SolicitudBusquedaDto>> PaginacionBusquedaSolicitud([FromQuery] RequestPagination<SolicitudBusquedaDto> request)
            => await _solicitudService.PaginacionSolicitud(request);

    }
}
