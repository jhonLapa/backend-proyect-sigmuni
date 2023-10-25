using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class AntiguedadController : ControllerBase
    {
        private readonly IAntiguedadService _AntiguedadService;

        public AntiguedadController(IAntiguedadService AntiguedadService)
        {
            _AntiguedadService = AntiguedadService;
        }


        [HttpGet]
        public async Task<IEnumerable<AntiguedadDto>> Get()
       => await _AntiguedadService.FindAll();

    }
}
