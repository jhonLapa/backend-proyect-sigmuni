using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class SectorController : ControllerBase
    {
        private readonly ISectorService _sectorService;

        public SectorController(ISectorService sectorService)
        {
            _sectorService = sectorService;
        }


 

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<SectorDto>> PaginatedSearch([FromQuery] RequestPagination<SectorDto> request)
        => await _sectorService.PaginatedSearch(request);
    }
}
