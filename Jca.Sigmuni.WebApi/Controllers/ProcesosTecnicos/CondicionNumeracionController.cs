using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CondicionNumeracionController : ControllerBase
    {
        private readonly ICondicionNumeracionService _condicionNumeracionService;

        public CondicionNumeracionController(ICondicionNumeracionService condicionNumeracionService)
        {
            _condicionNumeracionService = condicionNumeracionService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionNumeracionDto>> Get()
       => await _condicionNumeracionService.FindAll();

    }
}
