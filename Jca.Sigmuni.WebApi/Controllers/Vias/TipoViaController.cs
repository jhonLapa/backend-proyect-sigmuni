using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Services.Vias.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Vias
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoViaController : ControllerBase
    {
        private readonly ITipoViaService _tipoViaService;

        public TipoViaController(ITipoViaService tipoViaService)
        {
            _tipoViaService = tipoViaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoViaDto>> Get()
       => await _tipoViaService.FindAll();


    }
}
