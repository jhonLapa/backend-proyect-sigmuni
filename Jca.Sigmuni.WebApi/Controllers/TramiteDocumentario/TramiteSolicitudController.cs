using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class TramiteSolicitudController:ControllerBase
    {
        private readonly ILogger<TramiteSolicitudController> _logger;
        private readonly ITramiteSolicitudService _tramiteSolicitudService;
        public TramiteSolicitudController(ILogger<TramiteSolicitudController> logger, ITramiteSolicitudService tramiteSolicitudService)
        {
            _logger = logger;
            _tramiteSolicitudService = tramiteSolicitudService;
        }

        [HttpGet("PaginatedSearchTramite")]
        public async Task<ResponsePagination<TramiteSolicitudDto>> PaginatedSearch([FromQuery] RequestPagination<TramiteSolicitudDto> request)
        =>await _tramiteSolicitudService.PaginatedSearch(request);
    }
}
