using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Habilitaciones
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class HabilitacionUrbanaController : ControllerBase
    {
        private readonly IHabilitacionUrbanaService _habilitacionUrbanaService;

        public HabilitacionUrbanaController(IHabilitacionUrbanaService habilitacionUrbanaService)
        {
            _habilitacionUrbanaService = habilitacionUrbanaService;
        }


        [HttpGet]
        public async Task<IEnumerable<HabilitacionUrbanaDto>> Get()
       => await _habilitacionUrbanaService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<HabilitacionUrbanaDto>> PaginatedSearch([FromQuery] RequestPagination<HabilitacionUrbanaBusquedaDto> request)
         => await _habilitacionUrbanaService.PaginatedSearch(request);
    }
}
