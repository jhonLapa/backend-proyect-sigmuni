using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoOtraInstalacionController : ControllerBase
    {
        private readonly ITipoOtraInstalacionService _tipoOtraInstalacionService;

        public TipoOtraInstalacionController(ITipoOtraInstalacionService tipoOtraInstalacionService)
        {
            _tipoOtraInstalacionService = tipoOtraInstalacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoOtraInstalacionDto>> Get()
        => await _tipoOtraInstalacionService.FindAll();
    }
}
