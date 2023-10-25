using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Application.Services.Admins.Inplementations;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.WebApi.Controllers.Admins;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoContactoController : Controller
    {
        private readonly ILogger<InfoContactoController> _logger;
        private readonly IInfoContactoService _infoContactoService;

        public InfoContactoController(ILogger<InfoContactoController> logger, IInfoContactoService infoContactoService)
        {
            _logger = logger;
            _infoContactoService = infoContactoService;
        }

        [HttpGet("listar")]
        public async Task<IEnumerable<InfoContactoDto>> Get()
        => await _infoContactoService.FindAll();

        [HttpGet("obtener/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoContactoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<InfoContactoDto>>> Get(int id)
        {
            var response = await _infoContactoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost("Crear")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoContactoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<InfoContactoDto>>> Post([FromBody] InfoContactoFormDto request)
        {
            var response = await _infoContactoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("Actualizar/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(InfoContactoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<InfoContactoDto>>> Put(int id, [FromBody] InfoContactoFormDto request)
        {
            var response = await _infoContactoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<InfoContactoDto>> PaginatedSearch([FromQuery] RequestPagination<InfoContactoDto> request)
        => await _infoContactoService.PaginatedSearch(request);
    }
}
