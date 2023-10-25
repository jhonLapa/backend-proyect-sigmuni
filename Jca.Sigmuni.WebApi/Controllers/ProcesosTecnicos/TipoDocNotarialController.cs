using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocNotariales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoDocNotarialController : ControllerBase
    {
        private readonly ITipoDocNotarialService _tipoDocNotarialService;

        public TipoDocNotarialController(ITipoDocNotarialService tipoDocNotarialService)
        {
            _tipoDocNotarialService = tipoDocNotarialService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDocNotarialDto>> Get()
       => await _tipoDocNotarialService.FindAll();


    }
}
