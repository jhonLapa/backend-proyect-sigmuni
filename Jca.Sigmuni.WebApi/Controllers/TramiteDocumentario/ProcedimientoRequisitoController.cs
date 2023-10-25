using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProcedimientoRequisitos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedimientoRequisitoController : ControllerBase
    {
        private readonly ILogger<ProcedimientoRequisitoController> _logger;
        private readonly IProcedimientoRequisitoService _procedimientoRequisitoService;

        public ProcedimientoRequisitoController(ILogger<ProcedimientoRequisitoController> logger, IProcedimientoRequisitoService procedimientoRequisitoService)
        {
            _logger = logger;
            _procedimientoRequisitoService = procedimientoRequisitoService;
        }



        [HttpGet("BusquedaRequisitos/{idProcedimiento}")]
        public async Task<IEnumerable<ProcedimientoRequisitoDto>> BusquedaRequisitos(int idProcedimiento)
            => await _procedimientoRequisitoService.ListarPorProcedimiento(idProcedimiento);

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProcedimientoRequisitoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ProcedimientoRequisitoDto>>> Delete(int id)
        {
            var response = await _procedimientoRequisitoService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

    }
}
