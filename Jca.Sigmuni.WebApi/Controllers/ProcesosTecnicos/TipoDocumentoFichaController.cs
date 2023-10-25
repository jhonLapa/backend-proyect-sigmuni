using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class TipoDocumentoFichaController : ControllerBase
    {
        private readonly ITipoDocumentoFichaService _tipoDocumentoFichaService;

        public TipoDocumentoFichaController(ITipoDocumentoFichaService tipoDocumentoFichaService)
        {
            _tipoDocumentoFichaService = tipoDocumentoFichaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDocumentoFichaDto>> Get()
       => await _tipoDocumentoFichaService.FindAll();

    }
}
