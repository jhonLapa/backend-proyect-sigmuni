using Jca.Sigmuni.Application.Dtos.General.Manzanas;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.General.Inplementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Busquedas
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class ManzanaController  : ControllerBase
    {
        private readonly IManzanaService _manzanaService;

        public ManzanaController(IManzanaService manzanaService)
        {
            _manzanaService = manzanaService;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ManzanaDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Results<NotFound, Ok<ManzanaDto>>> Get(string id)
        {
            var response = await _manzanaService.Find(id);

            if (response == null) return TypedResults.NotFound();

            return TypedResults.Ok(response);
        }


        [HttpGet]
        public async Task<IEnumerable<ManzanaDto>> Get()
       => await _manzanaService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ManzanaDto>> PaginatedSearch([FromQuery] RequestPagination<ManzanaBusquedaDto> request)
        => await _manzanaService.PaginatedSearch(request);

    }
}

