using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Admins
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreaController : ControllerBase
    {
        private readonly ILogger<AreaController> _logger;
        private readonly IAreaService _areaService;

        public AreaController(ILogger<AreaController> logger, IAreaService areaService)
        {
            _logger = logger;
            _areaService = areaService;
        }


        [HttpGet]
        public async Task<IEnumerable<AreaDto>> Get()
        => await _areaService.FindAll();

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<AreaDto>>> Get(int id)
        {
            var response = await _areaService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<Results<BadRequest, Ok<AreaDto>>> Post([FromBody] AreaFormDto request)
        {
            var response = await _areaService.Create(request);

            if (response == null) return TypedResults.BadRequest();

            return TypedResults.Ok(response);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<BadRequest, NotFound, Ok<AreaDto>>> Put(int id, [FromBody] AreaFormDto request)
        {
            var response = await _areaService.Edit(id, request);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(AreaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<AreaDto>>> Delete(int id)
        {
            var response = await _areaService.Disable(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<AreaDto>> PaginatedSearch([FromQuery] RequestPagination<AreaDto> request)
        => await _areaService.PaginatedSearch(request);

        [HttpGet("SelectAll")]
        public async Task<IEnumerable<AreaDto>> SelectAll()
        => await _areaService.SelectAll();
        [AllowAnonymous]

        [HttpGet("SelectPaginatedSearch")]
        public async Task<ResponsePagination<AreaDto>> SelectPaginatedSearch([FromQuery] RequestPagination<AreaDto> request)
        => await _areaService.SelectPaginatedSearch(request);
    }
}
