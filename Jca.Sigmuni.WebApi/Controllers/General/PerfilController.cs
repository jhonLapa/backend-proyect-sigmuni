using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly ILogger<PerfilController> _logger;
        private readonly IPerfilService _perfilService;

        public PerfilController(ILogger<PerfilController> logger, IPerfilService perfilService)
        {
            _logger = logger;
            _perfilService = perfilService;
        }


        [HttpGet]
        public async Task<IEnumerable<PerfilDto>> Get()
        => await _perfilService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerfilDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PerfilDto>>> Get(int id)
        {
            var response = await _perfilService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerfilDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<PerfilDto>>> Post([FromBody] PerfilFormDto request)
        {
            var response = await _perfilService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerfilDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<PerfilDto>>> Put(int id, [FromBody] PerfilFormDto request)
        {
            var response = await _perfilService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PerfilDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<PerfilDto>>> Delete(int id)
        {
            var response = await _perfilService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<PerfilDto>> PaginatedSearch([FromQuery] RequestPagination<PerfilDto> request)
        => await _perfilService.PaginatedSearch(request);
    }
}
