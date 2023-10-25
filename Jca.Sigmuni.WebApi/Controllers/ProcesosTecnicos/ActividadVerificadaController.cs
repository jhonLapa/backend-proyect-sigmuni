using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesVerificadas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ActividadVerificadaController : ControllerBase
    {
        private readonly IActividadVerificadaService _actividadVerificadaService;

        public ActividadVerificadaController(IActividadVerificadaService actividadVerificadaService)
        {
            _actividadVerificadaService = actividadVerificadaService;
        }


        [HttpGet]
        public async Task<IEnumerable<ActividadVerificadaDto>> Get()
       => await _actividadVerificadaService.FindAll();


    }
}
