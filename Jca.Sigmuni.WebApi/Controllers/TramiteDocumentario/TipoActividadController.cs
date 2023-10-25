using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoActividades;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class TipoActividadController:Controller
    {
        private readonly ITipoActividadService _tipoActividadService;

        public TipoActividadController(ITipoActividadService tipoActividadService)
        {
            _tipoActividadService = tipoActividadService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoActividadDto>>Get()
            =>await _tipoActividadService.findAll();    
    }
}
