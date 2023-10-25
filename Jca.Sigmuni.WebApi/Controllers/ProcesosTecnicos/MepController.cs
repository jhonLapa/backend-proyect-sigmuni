using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class MepController : ControllerBase
    {
        private readonly IMepService _mepService;

        public MepController(IMepService mepService)
        {
            _mepService = mepService;
        }


        [HttpGet]
        public async Task<IEnumerable<MepDto>> Get()
       => await _mepService.FindAll();


    }
}
