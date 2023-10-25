using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ValorUnitarioController : ControllerBase
    {
        private readonly IValorUnitarioService _valorUnitarioService;

        public ValorUnitarioController(IValorUnitarioService valorUnitarioService)
        {
            _valorUnitarioService = valorUnitarioService;
        }

        [HttpGet("SelectPaginatedSearch")]
        public async Task<ResponsePagination<ValorUnitarioDto>> SelectPaginatedSearch([FromQuery] RequestPagination<ValorUnitarioDto> request)
            => await _valorUnitarioService.SelectPaginatedSearch(request);

        [HttpPost("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorUnitarioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ValorUnitarioDto>>> Post([FromBody] ValorUnitarioDto request)
        {
            var operacion = await _valorUnitarioService.CrearOActualizarAsync(request);

            if (operacion == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }

        [HttpGet("Obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorUnitarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ValorUnitarioDto>>> Get(int id)
        {
            var response = await _valorUnitarioService.ObtenerAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorUnitarioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ValorUnitarioDto>>> Delete(int id)
        {
            var response = await _valorUnitarioService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
