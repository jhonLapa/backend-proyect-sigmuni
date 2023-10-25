using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoFichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoFichaController : ControllerBase
    {
        private readonly ITipoFichaService _tipoFichaService;

        public TipoFichaController(ITipoFichaService tipoFichaService)
        {
            _tipoFichaService = tipoFichaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoFichaDto>> Get()
       => await _tipoFichaService.FindAll();


    }
}
