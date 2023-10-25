using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class CondicionConductorController : ControllerBase
    {
        private readonly ICondicionConductorService _condicionConductorService;

        public CondicionConductorController(ICondicionConductorService condicionConductorService)
        {
            _condicionConductorService = condicionConductorService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionConductorDto>> Get()
       => await _condicionConductorService.FindAll();


    }
}
