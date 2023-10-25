using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeTecnicoController : ControllerBase
    {
        private readonly ILogger<InformeTecnicoController> _logger;
        private readonly IInformeTecnicoService _informeTecnicoService;
        private readonly IAdjuntoInformeService _adjuntoInformeService;

        public InformeTecnicoController(ILogger<InformeTecnicoController> logger, IInformeTecnicoService InformeTecnicoService, IAdjuntoInformeService adjuntoInformeService)
        {
            _logger = logger;
            _informeTecnicoService = InformeTecnicoService;
            _adjuntoInformeService = adjuntoInformeService;
        }

        [HttpGet("DatosSolicitud/{numSolicitud}")]
        public async Task<DatosSolicitudDto> ObtenerAsyncSolicitud(string numSolicitud)
        {


            var operacion = await _informeTecnicoService.ObtenerSolicitudAsync(numSolicitud);
            return operacion;

        }


        [HttpGet("ObtenerAsyncSolicitudxAnioxNumero/{numSolicitud}/{anio}")]
        public async Task<DatosSolicitudDto> ObtenerAsyncSolicitudxAnioxNumero(string numSolicitud ,int anio)
        {
            var operacion = await _informeTecnicoService.ObtenerAsyncSolicitudxAnioxNumero(numSolicitud, anio);
            return operacion;

        }

        [HttpPost("RegistrarInforme")]
        public async Task<InformeTecnicoRespuestaDto> CrearAsync(InformeTecnicoDto peticion)
        {
            //VerificarIfEsBuenJson(peticion);
            var operacion = await _informeTecnicoService.CrearAsync(peticion);
            return operacion;
        }

        [HttpGet("ObtenerMaxRegistroCorrelativo")]
        public async Task<string> BuscarMaxRegistroCorrelativoAsyn()
        {
            //var operacion = newnumeroCorrelativo;

            var operacion = await _informeTecnicoService.BuscarMaxRegistroCorrelativoAsyn();

            return operacion;
        }


        [HttpGet("ListarPorSolicitud/{idSolicitud}")]
        public async Task<List<SolicitudRequisitoDto>> ListarxSolicitudAsync(int idSolicitud)
        {
            var operacion = await _informeTecnicoService.ListarxSolicitudAsync(idSolicitud);
            return operacion;
        }


        [HttpGet("ObtenerxIdLoteCartografia/{IdLoteCartografia}")]
        //[RequiereAcceso()]
        public async Task<LoteZonificacionParametroDto> ObtenerxIdLoteCartografia(string IdLoteCartografia)
        {
            var operacion = await _informeTecnicoService.ObtenerPorIdLoteCartografiaAsync(IdLoteCartografia);
            return operacion;
        }


        [HttpGet("PaginacionInforme")]
        public async Task<ResponsePagination<InformeTecnicoPaginadoDto>> PaginacionInforme([FromQuery] RequestPagination<InformeTecnicoPaginadoDto> request)
          => await _informeTecnicoService.PaginatedSearch(request);

        //[AllowAnonymous]

        [HttpGet("Obtenerinforme/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InformeTecnicoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InformeTecnicoDto>>> Get(int id)
        {
            var response = await _informeTecnicoService.ObtenerinformeId(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        //[AllowAnonymous]

        [HttpPut("EstadoGeneradoInforme/{id}")]
        public async Task<InformeTecnicoDto> EstadoGeneradoInforme(int id)
        {
            var response = await _informeTecnicoService.EstadoGeneradoInforme(id);
            return response;
        }




        [HttpGet("ObtenerInformePorIdSolicitud/{idSolicitud}")]
        public async Task<InformeTecnicoDto> ObtenerInformePorIdSolicitud(int idSolicitud)
        {
            var operacion = await _informeTecnicoService.ObtenerInformePorIdSolicitud(idSolicitud);
            return operacion;

        }

        [HttpPost("AdjuntoInforme")]
        //[RequiereAcceso()]
        public async Task<bool> AdjuntarDocumentoAsync(InformeDocumento peticion)
        {
            var operacion = await _adjuntoInformeService.AdjuntarDocumentoAsync(peticion);
            return operacion;
        }

        [HttpPost("AdjuntarDocumentoDescripcion")]
        //[RequiereAcceso()]
        public async Task<bool> AdjuntarDocumentoDescripcionAsync(InformeDocumento peticion)
        {
            var operacion = await _adjuntoInformeService.AdjuntarDocumentoDescripcionAsync(peticion);
            return operacion;
        }

    }
}
