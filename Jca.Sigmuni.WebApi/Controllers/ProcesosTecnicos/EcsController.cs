using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class EcsController : ControllerBase
    {
        private readonly IEcsService _ecsService;

        public EcsController(IEcsService ecsService)
        {
            _ecsService = ecsService;
        }


        [HttpGet]
        public async Task<IEnumerable<EcsDto>> Get()
       => await _ecsService.FindAll();


    }
}
