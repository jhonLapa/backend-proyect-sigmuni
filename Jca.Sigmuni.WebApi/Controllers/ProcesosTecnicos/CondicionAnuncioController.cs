using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionAnuncios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class CondicionAnuncioController : ControllerBase
    {
        private readonly ICondicionAnuncioService _condicionAnuncioService;

        public CondicionAnuncioController(ICondicionAnuncioService condicionAnuncioService)
        {
            _condicionAnuncioService = condicionAnuncioService;
        }


        [HttpGet]
        public async Task<IEnumerable<CondicionAnuncioDto>> Get()
       => await _condicionAnuncioService.FindAll();


    }
}
