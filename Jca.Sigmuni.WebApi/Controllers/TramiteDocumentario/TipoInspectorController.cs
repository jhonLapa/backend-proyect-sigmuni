using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoInspectors;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoInspectorController : ControllerBase
    {
        private readonly ITipoInspectorService _TipoInspectorService;

        public TipoInspectorController(ITipoInspectorService TipoInspectorService)
        {
            _TipoInspectorService = TipoInspectorService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoInspectorDto>> Get()
       => await _TipoInspectorService.FindAll();


    }
}
