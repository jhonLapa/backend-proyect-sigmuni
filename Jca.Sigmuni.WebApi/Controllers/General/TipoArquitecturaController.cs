using Jca.Sigmuni.Application.Dtos.General.TipoArquitecturas;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class TipoArquitecturaController : ControllerBase
    {
        private readonly ITipoArquitecturaService _tipoArquitecturaService;

        public TipoArquitecturaController(ITipoArquitecturaService tipoArquitecturaService)
        {
            _tipoArquitecturaService = tipoArquitecturaService;
        }


        [HttpGet("listarPorGrupo/{grupo}")]
        public async Task<IEnumerable<TipoArquitecturaDto>> listarPorGrupo(string grupo)
       => await _tipoArquitecturaService.FindAllPorGrupo(grupo);

    }
}
