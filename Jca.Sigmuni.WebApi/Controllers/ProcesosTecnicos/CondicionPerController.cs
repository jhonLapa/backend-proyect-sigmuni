using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CondicionPerController : ControllerBase
    {
        private readonly ICondicionPerService _condicionPerService;

        public CondicionPerController(ICondicionPerService condicionPerService)
        {
            _condicionPerService = condicionPerService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionPerDto>> Get()
       => await _condicionPerService.FindAll();

    }
}
