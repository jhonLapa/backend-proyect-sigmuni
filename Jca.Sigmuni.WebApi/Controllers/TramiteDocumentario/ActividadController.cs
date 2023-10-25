using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class ActividadController : ControllerBase
    {
        private readonly ILogger<ActividadController> logger;
        private readonly IActividadService _actividadService;

        public ActividadController(ILogger<ActividadController> logger, IActividadService actividadService)
        {
            this.logger = logger;
            _actividadService = actividadService;
        }

    }
}
