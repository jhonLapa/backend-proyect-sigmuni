using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoInspeccionController : ControllerBase
    {
        private readonly ITipoInspeccionService _tipoInspeccionService;

        public TipoInspeccionController(ITipoInspeccionService tipoInspeccionService)
        {
            _tipoInspeccionService = tipoInspeccionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoInspeccionDto>> Get()
       => await _tipoInspeccionService.FindAll();


    }
}
