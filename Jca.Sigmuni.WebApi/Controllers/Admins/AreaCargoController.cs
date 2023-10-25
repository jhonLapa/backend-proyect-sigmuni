using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaCargoController : ControllerBase
    {
        private readonly ILogger<AreaCargoController> _logger;
        private readonly IAreaCargoService _areaCargoService;

        public AreaCargoController(ILogger<AreaCargoController> logger, IAreaCargoService areaCargoService)
        {
            _logger = logger;
            _areaCargoService = areaCargoService;
        }


        [HttpGet]
        public async Task<IEnumerable<AreaCargoDto>> Get()
        => await _areaCargoService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaCargoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<AreaCargoDto>>> Get(int id)
        {
            var response = await _areaCargoService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaCargoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<AreaCargoDto>>> Post([FromBody] AreaCargoFormDto request)
        {
            var response = await _areaCargoService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaCargoDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<AreaCargoDto>>> Put(int id, [FromBody] AreaCargoFormDto request)
        {
            var response = await _areaCargoService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaCargoDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<AreaCargoDto>>> Delete(int id)
        {
            var response = await _areaCargoService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<AreaCargoDto>> PaginatedSearch([FromQuery] RequestPagination<AreaCargoDto> request)
        => await _areaCargoService.PaginatedSearch(request);
    }
}