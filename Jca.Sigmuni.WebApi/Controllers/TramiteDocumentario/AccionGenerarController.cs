using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.AcccionesGenerar;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class AccionGenerarController
    {
        private readonly IAccionGenerarService _accionGenerarService;

        public AccionGenerarController(IAccionGenerarService accionGenerarService)
        {
            _accionGenerarService = accionGenerarService;
        }

        [HttpGet]
        public async  Task<IEnumerable<AccionGenerarDto>> Get()
            => await _accionGenerarService.findAll();
    }
}
