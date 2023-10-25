using Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class AfectacionAntropicaController : ControllerBase
    {
        private readonly IAfectacionAntropicaService _afectacionAntropicaService;

        public AfectacionAntropicaController(IAfectacionAntropicaService afectacionAntropicaService)
        {
            _afectacionAntropicaService = afectacionAntropicaService;
        }


        [HttpGet]
        public async Task<IEnumerable<AfectacionAntropicaDto>> Get()
       => await _afectacionAntropicaService.FindAll();

    }
}
