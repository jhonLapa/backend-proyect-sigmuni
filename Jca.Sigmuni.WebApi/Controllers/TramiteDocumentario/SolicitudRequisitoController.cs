using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class SolicitudRequisitoController :ControllerBase
    {
        private readonly ILogger<SolicitudController> _logger;
        private readonly ISolicitudRequisitoService _solicitudRequisitoService;

        public SolicitudRequisitoController(ILogger<SolicitudController> logger, ISolicitudRequisitoService solicitudRequisitoService)
        {
            _logger = logger;
            _solicitudRequisitoService = solicitudRequisitoService;
        }

        [HttpPut("ActualizarRevisarRequisito/{idSolicitudRequisito}/{revision}")]
        public async Task<bool> ActualizarRevisarRequisito(int idSolicitudRequisito, string revision)
        {
            var operacion = await _solicitudRequisitoService.ActualizarRevisionRequisitoPresentadoAsync(idSolicitudRequisito, revision);
            return operacion;
        }

        [HttpDelete("{idSolicitudRequisito}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SolicitudRequisitoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound,Ok<SolicitudRequisitoDto>>> Delete(int idSolicitudRequisito)
        {
            var response = await _solicitudRequisitoService.EliminarDocumentoSolicitudRequisito(idSolicitudRequisito);
            if(response==null)
            {
                return TypedResults.NotFound();
            }
            return TypedResults.Ok(response);
        }

    }
}
