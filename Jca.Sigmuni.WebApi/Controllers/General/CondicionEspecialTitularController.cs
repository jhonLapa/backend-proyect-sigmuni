using Jca.Sigmuni.Application.Dtos.General.CondicionEspecialTitulares;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CondicionEspecialTitularController : ControllerBase
    {
        private readonly ICondicionEspecialTitularService _condicionEspecialTitularService;

        public CondicionEspecialTitularController(ICondicionEspecialTitularService condicionEspecialTitularService)
        {
            _condicionEspecialTitularService = condicionEspecialTitularService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionEspecialTitularDto>> Get()
       => await _condicionEspecialTitularService.FindAll();

    }
}
