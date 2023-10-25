using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAgrupaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoAgrupacionController : ControllerBase
    {
        private readonly ITipoAgrupacionService _tipoAgrupacionService;

        public TipoAgrupacionController(ITipoAgrupacionService tipoAgrupacionService)
        {
            _tipoAgrupacionService = tipoAgrupacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoAgrupacionDto>> Get()
       => await _tipoAgrupacionService.FindAll();


    }
}
