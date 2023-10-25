using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class EccController : ControllerBase
    {
        private readonly IEccService _eccService;

        public EccController(IEccService eccService)
        {
            _eccService = eccService;
        }


        [HttpGet]
        public async Task<IEnumerable<EccDto>> Get()
       => await _eccService.FindAll();


    }
}
