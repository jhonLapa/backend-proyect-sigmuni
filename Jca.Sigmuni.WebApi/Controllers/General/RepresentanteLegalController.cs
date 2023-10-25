using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepresentanteLegalController : Controller
    {
        private readonly ILogger<RepresentanteLegalController> _logger;
        private readonly IRepresentanteLegalService _representanteLegalService;

        public RepresentanteLegalController(ILogger<RepresentanteLegalController> logger, IRepresentanteLegalService representanteLegalService)
        {
            _logger = logger;
            _representanteLegalService = representanteLegalService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<RepresentanteLegalDto>> Get()
        => await _representanteLegalService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentanteLegalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<RepresentanteLegalDto>>> Get(int id)
        {
            var response = await _representanteLegalService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentanteLegalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<RepresentanteLegalDto>>> Post([FromBody] RepresentanteLegalFormDto request)
        {
            var response = await _representanteLegalService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentanteLegalDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<RepresentanteLegalDto>>> Put(int id, [FromBody] RepresentanteLegalFormDto request)
        {
            var response = await _representanteLegalService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("Eliminar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RepresentanteLegalDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<RepresentanteLegalDto>>> Delete(int id)
        {
            var response = await _representanteLegalService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<RepresentanteLegalDto>> PaginatedSearch([FromQuery] RequestPagination<RepresentanteLegalDto> request)
        => await _representanteLegalService.PaginatedSearch(request);
    }
}
