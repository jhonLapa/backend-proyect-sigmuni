using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class DomicilioController : Controller
    {
        private readonly ILogger<DomicilioController> _logger;
        private readonly IDomicilioService _domicilioService;

        public DomicilioController(ILogger<DomicilioController> logger, IDomicilioService domicilioService)
        {
            _logger = logger;
            _domicilioService = domicilioService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<DomicilioDto>> Get()
        => await _domicilioService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomicilioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DomicilioDto>>> Get(int id)
        {
            var response = await _domicilioService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("obtenerPorPersona/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomicilioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DomicilioDto>>> GetDomicilioxPersona(int id)
        {
            var response = await _domicilioService.ObtenerPorIdPersonaAsync(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomicilioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<DomicilioDto>>> Post([FromBody] DomicilioFormDto request)
        {
            var response = await _domicilioService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomicilioDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<DomicilioDto>>> Put(int id, [FromBody] DomicilioFormDto request)
        {
            var response = await _domicilioService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DomicilioDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<DomicilioDto>>> Delete(int id)
        {
            var response = await _domicilioService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<DomicilioDto>> PaginatedSearch([FromQuery] RequestPagination<DomicilioDto> request)
        => await _domicilioService.PaginatedSearch(request);
    }
}
