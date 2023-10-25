using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoMantenimientoController : ControllerBase
    {
        private readonly ITipoMantenimientoService _tipoMantenimientoService;

        public TipoMantenimientoController(ITipoMantenimientoService tipoMantenimientoService)
        {
            _tipoMantenimientoService = tipoMantenimientoService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoMantenimientoDto>> Get()
       => await _tipoMantenimientoService.FindAll();


    }
}
