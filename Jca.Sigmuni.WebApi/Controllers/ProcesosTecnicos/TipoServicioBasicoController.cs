using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoServicioBasicoController : ControllerBase
    {
        private readonly ITipoServicioBasicoService _tipoServicioBasicoService;

        public TipoServicioBasicoController(ITipoServicioBasicoService tipoServicioBasicoService)
        {
            _tipoServicioBasicoService = tipoServicioBasicoService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoServicioBasicoDto>> Get()
        => await _tipoServicioBasicoService.FindAll();

        [HttpGet("ListarPorGrupo/{grupo}")]
        public async Task<IEnumerable<TipoServicioBasicoDto>> GetPorGrupo(string grupo)
        {
            return await _tipoServicioBasicoService.ListarGrupoAsync(grupo);
        }
    }
}
