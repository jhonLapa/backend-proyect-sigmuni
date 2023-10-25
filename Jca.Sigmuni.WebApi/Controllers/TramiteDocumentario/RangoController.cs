using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Rangos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class RangoController:Controller
    {
        private readonly IRangoService _rangoService;
        public RangoController(IRangoService rangoService)
        { 
            _rangoService= rangoService;
        }

        [HttpGet]
        public async Task<IEnumerable<RangoDto>> Get()
            => await _rangoService.findAll();
    }
}
