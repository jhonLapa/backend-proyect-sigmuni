using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoTituloInscritos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoTituloInscritoController : ControllerBase
    {
        private readonly ITipoTituloInscritoService _tipoTituloInscritoService;

        public TipoTituloInscritoController(ITipoTituloInscritoService tipoTituloInscritoService)
        {
            _tipoTituloInscritoService = tipoTituloInscritoService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoTituloInscritoDto>> Get()
       => await _tipoTituloInscritoService.FindAll();


    }
}
