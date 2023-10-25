using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class TipoTramiteController:Controller
    {
        private readonly ITipoTramiteService _tipoTramiteService;

        public TipoTramiteController(ITipoTramiteService tipoTramiteService)
        {
            _tipoTramiteService = tipoTramiteService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoTramiteDto>> Get()
            => await _tipoTramiteService.findAll();
    }
}
