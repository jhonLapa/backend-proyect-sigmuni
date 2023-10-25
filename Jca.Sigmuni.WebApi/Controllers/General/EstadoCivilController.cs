using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : ControllerBase
    {
        private readonly ILogger<EstadoCivilController> _logger;
        private readonly IEstadoCivilService _areaService;

        public EstadoCivilController(ILogger<EstadoCivilController> logger, IEstadoCivilService areaService)
        {
            _logger = logger;
            _areaService = areaService;
        }


        [HttpGet]
        public async Task<IEnumerable<EstadoCivilDto>> Get()
        => await _areaService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstadoCivilDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<EstadoCivilDto>>> Get(int id)
        {
            var response = await _areaService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstadoCivilDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<EstadoCivilDto>>> Post([FromBody] EstadoCivilFormDto request)
        {
            var response = await _areaService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstadoCivilDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<EstadoCivilDto>>> Put(int id, [FromBody] EstadoCivilFormDto request)
        {
            var response = await _areaService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EstadoCivilDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<EstadoCivilDto>>> Delete(int id)
        {
            var response = await _areaService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<EstadoCivilDto>> PaginatedSearch([FromQuery] RequestPagination<EstadoCivilDto> request)
        => await _areaService.PaginatedSearch(request);
    }
}
