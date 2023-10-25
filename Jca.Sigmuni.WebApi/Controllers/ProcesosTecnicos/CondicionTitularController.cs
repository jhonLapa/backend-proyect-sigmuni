using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesTitulares;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class CondicionTitularController : ControllerBase
    {
        private readonly ICondicionTitularService _condicionTitularService;

        public CondicionTitularController(ICondicionTitularService condicionTitularService)
        {
            _condicionTitularService = condicionTitularService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionTitularDto>> Get()
       => await _condicionTitularService.FindAll();


    }
}
