using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ClasificacionValorUnitarioController : ControllerBase
    {
        private readonly IClasificacionValorUnitarioService _clasificacionValorUnitarioService;

        public ClasificacionValorUnitarioController(IClasificacionValorUnitarioService clasificacionValorUnitarioService)
        {
            _clasificacionValorUnitarioService = clasificacionValorUnitarioService;
        }


        [HttpGet]
        public async Task<IEnumerable<ClasificacionValorUnitarioDto>> Get()
        => await _clasificacionValorUnitarioService.FindAll();
    }
}
