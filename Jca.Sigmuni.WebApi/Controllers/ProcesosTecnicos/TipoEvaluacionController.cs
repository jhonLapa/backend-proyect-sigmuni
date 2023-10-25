using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEvaluaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoEvaluacionController : ControllerBase
    {
        private readonly ITipoEvaluacionService _tipoEvaluacionService;

        public TipoEvaluacionController(ITipoEvaluacionService tipoEvaluacionService)
        {
            _tipoEvaluacionService = tipoEvaluacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoEvaluacionDto>> Get()
       => await _tipoEvaluacionService.FindAll();


    }
}
