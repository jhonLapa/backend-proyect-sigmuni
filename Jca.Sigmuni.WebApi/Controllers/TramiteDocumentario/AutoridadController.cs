using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class AutoridadController:Controller
    {
        private readonly IAutoridadService _autoridadService;

        public AutoridadController(IAutoridadService autoridadService)
        {
            _autoridadService = autoridadService;
        }

        [HttpGet]
        public async Task<IEnumerable<AutoridadDto>>Get()
            =>await _autoridadService.findAll();
    }
}
