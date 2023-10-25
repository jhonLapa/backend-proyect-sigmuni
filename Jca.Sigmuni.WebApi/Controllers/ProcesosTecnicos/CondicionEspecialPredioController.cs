using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class CondicionEspecialPredioController : ControllerBase
    {
        private readonly ICondicionEspecialPredioService _condicionEspecialPredioService;

        public CondicionEspecialPredioController(ICondicionEspecialPredioService condicionEspecialPredioService)
        {
            _condicionEspecialPredioService = condicionEspecialPredioService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionEspecialPredioDto>> Get()
       => await _condicionEspecialPredioService.FindAll();


    }
}
