using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformeDocumentoController : ControllerBase
    {
        private readonly ILogger<InformeDocumentoController> _logger;
        private readonly IAdjuntoInformeService _adjuntoInformeService;

        public InformeDocumentoController(ILogger<InformeDocumentoController> logger, IAdjuntoInformeService AdjuntoInformeService)
        {
            _logger = logger;
            _adjuntoInformeService = AdjuntoInformeService;
        }
        [AllowAnonymous]
        [HttpGet("BuscarInformeDocumento/{idInforme}/{flag}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InformeDocumentoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InformeDocumentoDto>>> Get(int idInforme, int flag)
        {
            var response = await _adjuntoInformeService.BuscarInformeDocumento(idInforme, flag);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        //[HttpGet("BuscarInformeDocumentoDescripcion/{idInforme}/{flag}/{descripcion}")]
        //[RequiereAcceso()]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InformeDocumentoDto))]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]

        //public async Task<Results<NotFound, Ok<InformeDocumentoDto>>> Get(int idInforme, int flag, string descripcion)
        //{
        //    var response = await _adjuntoInformeService.BuscarInformeDocumentoDescripcion(idInforme, flag ,descripcion);

        //    if (response == null) return TypedResults.NotFound();

        //    return TypedResults.Ok(response);
        //}

        [AllowAnonymous]

        [HttpGet("BuscarInformeDocumentoDescripcion/{idInforme}/{flag}/{descripcion}")]

        public async Task<InformeDocumentoDto> BuscarInformeDocumentoDescripcion(int idInforme, int flag, string descripcion)
        {
            var operacion = await _adjuntoInformeService.BuscarInformeDocumentoDescripcion(idInforme, flag, descripcion);
            return operacion;

        }



        [AllowAnonymous]
        [HttpPost("Disable")]
        public async Task<bool> Disable(InformeDocumentoDto peticion)
        {
            var operacion = await _adjuntoInformeService.Disable(peticion);
            return operacion;
        }

    }
}
