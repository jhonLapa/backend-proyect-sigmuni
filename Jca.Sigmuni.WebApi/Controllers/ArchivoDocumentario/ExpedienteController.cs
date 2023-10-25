using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes;
using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;
using Jca.Sigmuni.Application.Services.ArchivoDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ArchivoDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpedienteController : ControllerBase
    {
        private readonly ILogger<ExpedienteController> _logger;
        private readonly IExpedienteService _expedienteService;

        public ExpedienteController(ILogger<ExpedienteController> logger, IExpedienteService expedienteService)
        {
            _logger = logger;
            _expedienteService = expedienteService;
        }
        [HttpGet("listar")]
        public async Task<IEnumerable<ExpedienteDto>> Get()
        => await _expedienteService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpedienteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ExpedienteDto>>> Get(int id)
        {
            var response = await _expedienteService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpedienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<ExpedienteDto>>> Post([FromBody] ExpedienteFormDto request)
        {
            var response = await _expedienteService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }
        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpedienteDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<ExpedienteDto>>> Put(int id, [FromBody] ExpedienteFormDto request)
        {
            var response = await _expedienteService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ExpedienteDto>> PaginatedSearch([FromQuery] RequestPagination<ExpedienteDto> request)
        => await _expedienteService.PaginatedSearch(request);

        [HttpGet("BuscarExpexInfo/{id}")]
        public async Task<ExpedienteDto> FindxInfo(int id)
        => await _expedienteService.FindxInfo(id);

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ExpedienteDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ExpedienteDto>>> Delete(int id)
        {
            var response = await _expedienteService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }
    }
}
