using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
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
    public class TipoPersonaController : ControllerBase
    {
        private readonly ILogger<TipoPersonaController> _logger;
        private readonly ITipoPersonaService _tipoPersonaService;

        public TipoPersonaController(ILogger<TipoPersonaController> logger, ITipoPersonaService tipoPersonaService)
        {
            _logger = logger;
            _tipoPersonaService = tipoPersonaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoPersonaDto>> Get()
        => await _tipoPersonaService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPersonaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoPersonaDto>>> Get(int id)
        {
            var response = await _tipoPersonaService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPersonaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<TipoPersonaDto>>> Post([FromBody] TipoPersonaFormDto request)
        {
            var response = await _tipoPersonaService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPersonaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<TipoPersonaDto>>> Put(int id, [FromBody] TipoPersonaFormDto request)
        {
            var response = await _tipoPersonaService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TipoPersonaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<TipoPersonaDto>>> Delete(int id)
        {
            var response = await _tipoPersonaService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<TipoPersonaDto>> PaginatedSearch([FromQuery] RequestPagination<TipoPersonaDto> request)
        => await _tipoPersonaService.PaginatedSearch(request);
    }
}
