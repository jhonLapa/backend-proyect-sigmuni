using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoPartidaRegistralController : ControllerBase
    {
        private readonly ITipoPartidaRegistralService _tipoPartidaRegistralService;

        public TipoPartidaRegistralController(ITipoPartidaRegistralService tipoPartidaRegistralService)
        {
            _tipoPartidaRegistralService = tipoPartidaRegistralService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoPartidaRegistralDto>> Get()
       => await _tipoPartidaRegistralService.FindAll();


    }
}
