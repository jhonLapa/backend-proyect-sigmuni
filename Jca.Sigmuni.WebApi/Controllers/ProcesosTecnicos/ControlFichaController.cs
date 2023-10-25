using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ControlFichaController : ControllerBase
    {
        private readonly IControlFichaService _controlFichaService;

        public ControlFichaController(IControlFichaService controlFichaService)
        {
            _controlFichaService = controlFichaService;
        }

        [HttpGet("ControlFichasPorIdFicha/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ControlFichaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<List<ControlFichaDto>>>> ControlFichasPorIdFicha(int id)
        {
            var response = await _controlFichaService.ControlFichasPorIdFicha(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ControlFichaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<bool>>> GuardarAsync([FromBody] List<ControlFichaDto> request)
        {
            var operacion = await _controlFichaService.GuardarControlFichaAsync(request);

            if (operacion == false) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }

        [HttpGet("GuardarDerivarControlFicha/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<bool>>> GuardarDerivarControlFichaAsync(int id)
        {
            var response = await _controlFichaService.GuardarDerivarControlFichaAsync(id);

            if (response == false) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("BuscarAsociadasPorIdFicha/{idFicha}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<ControlFichaDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<List<ControlFichaDto>>>> FichasAsociadasPorIdFicha(int idFicha)
        {
            var response = await _controlFichaService.ListadoFichasAsociadasPorIdFichaAsync(idFicha);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("ConfirmControlFicha/{idFicha}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<bool>>> FichaControlConfirmAsync(int idFicha)
        {
            var response = await _controlFichaService.FichaControlConfirmAsync(idFicha);

            if (response == false) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
