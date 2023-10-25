using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Application.Services.Vias.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Vias
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ViaController : ControllerBase
    {
        private readonly IViaService _ViaService;

        public ViaController(IViaService ViaService)
        {
            _ViaService = ViaService;
        }


        [HttpGet]
        public async Task<IEnumerable<ViaDto>> Get()
       => await _ViaService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ViaDto>> PaginatedSearch([FromQuery] RequestPagination<ViaBusquedaDto> request)
         => await _ViaService.PaginatedSearch(request);
    }
}
