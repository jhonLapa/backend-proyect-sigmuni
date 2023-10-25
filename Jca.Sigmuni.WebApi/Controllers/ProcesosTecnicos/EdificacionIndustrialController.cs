using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class EdificacionIndustrialController : ControllerBase
    {
        private readonly IEdificacionIndustrialService _edificacionIndustrialService;

        public EdificacionIndustrialController(IEdificacionIndustrialService edificacionIndustrialService)
        {
            _edificacionIndustrialService = edificacionIndustrialService;
        }


        [HttpGet]
        public async Task<IEnumerable<EdificacionIndustrialDto>> Get()
       => await _edificacionIndustrialService.FindAll();


    }
}
