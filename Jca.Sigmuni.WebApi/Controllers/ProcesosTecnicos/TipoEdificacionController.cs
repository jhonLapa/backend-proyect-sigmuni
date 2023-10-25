using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEdificaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoEdificacionController : ControllerBase
    {
        private readonly ITipoEdificacionService _tipoEdificacionService;

        public TipoEdificacionController(ITipoEdificacionService tipoEdificacionService)
        {
            _tipoEdificacionService = tipoEdificacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoEdificacionDto>> Get()
       => await _tipoEdificacionService.FindAll();


    }
}
