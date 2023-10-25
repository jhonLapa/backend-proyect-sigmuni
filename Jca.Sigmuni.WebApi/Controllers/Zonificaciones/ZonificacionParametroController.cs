using Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros;
using Jca.Sigmuni.Application.Services.Zonificaciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Zonificaciones
{
    [Route("api/zonificaciones/[controller]")]
    [ApiController]
    public class ZonificacionParametroController : ControllerBase
    {
        private readonly IZonificacionParametrosService _zonificacionParametroService;

        public ZonificacionParametroController(IZonificacionParametrosService ZonificacionParametroService)
        {
            _zonificacionParametroService = ZonificacionParametroService;
        }


        [HttpGet]
        public async Task<IEnumerable<ZonificacionParametroDto>> Get()
       => await _zonificacionParametroService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ZonificacionParametroDto>> PaginatedSearch([FromQuery] RequestPagination<ZonificacionParametroDto> request)
         => await _zonificacionParametroService.PaginatedSearch(request);
    }
}
