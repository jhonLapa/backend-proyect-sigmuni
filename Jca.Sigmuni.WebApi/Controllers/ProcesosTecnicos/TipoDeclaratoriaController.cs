using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoDeclaratoriaController : ControllerBase
    {
        private readonly ITipoDeclaratoriaService _tipoDeclaratoriaService;

        public TipoDeclaratoriaController(ITipoDeclaratoriaService tipoDeclaratoriaService)
        {
            _tipoDeclaratoriaService = tipoDeclaratoriaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDeclaratoriaDto>> Get()
       => await _tipoDeclaratoriaService.FindAll();


    }
}
