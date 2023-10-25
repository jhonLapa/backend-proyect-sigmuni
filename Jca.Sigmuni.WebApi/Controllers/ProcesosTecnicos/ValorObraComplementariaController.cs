using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ValorObraComplementariaController : ControllerBase
    {
        private readonly IValorObraComplementariaService _valorObraComplementariaService;

        public ValorObraComplementariaController(IValorObraComplementariaService valorObraComplementariaService)
        {
            _valorObraComplementariaService = valorObraComplementariaService;
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ValorObraComplementariaDto>> SelectPaginatedSearch([FromQuery] RequestPagination<ValorObraComplementariaDto> request)
            => await _valorObraComplementariaService.PaginatedSearch(request);

        [HttpPost("Guardar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorObraComplementariaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ValorObraComplementariaDto>>> Post([FromBody] ValorObraComplementariaDto request)
        {
            var operacion = await _valorObraComplementariaService.CrearOActualizarAsync(request);

            if (operacion == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }

        [HttpGet("Obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorObraComplementariaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ValorObraComplementariaDto>>> Get(int id)
        {
            var response = await _valorObraComplementariaService.ObtenerAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("CrearMasivo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorObraComplementariaMasivoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<List<ValorObraComplementariaDto>>>> Post([FromBody] List<ValorObraComplementariaMasivoDto> request)
        {
            var operacion = await _valorObraComplementariaService.CrearMasivoAsync(request);

            if (operacion == null) return TypedResults.BadRequest();

            return TypedResults.Ok(operacion);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ValorObraComplementariaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ValorObraComplementariaDto>>> Delete(int id)
        {
            var response = await _valorObraComplementariaService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
