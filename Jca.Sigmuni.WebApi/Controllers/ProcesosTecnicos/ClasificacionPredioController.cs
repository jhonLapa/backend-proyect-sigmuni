using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ClasificacionPredioController : ControllerBase
    {
        private readonly IClasificacionPredioService _clasificacionPredioService;

        public ClasificacionPredioController(IClasificacionPredioService clasificacionPredioService)
        {
            _clasificacionPredioService = clasificacionPredioService;
        }


        [HttpGet]
        public async Task<IEnumerable<ClasificacionPredioDto>> Get()
       => await _clasificacionPredioService.FindAll();


    }
}
