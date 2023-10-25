using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoDocumentoObraController : ControllerBase
    {
        private readonly ITipoDocumentoObraService _tipoDocumentoObraService;

        public TipoDocumentoObraController(ITipoDocumentoObraService tipoDocumentoObraService)
        {
            _tipoDocumentoObraService = tipoDocumentoObraService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDocumentoObraDto>> Get()
       => await _tipoDocumentoObraService.FindAll();


    }
}
