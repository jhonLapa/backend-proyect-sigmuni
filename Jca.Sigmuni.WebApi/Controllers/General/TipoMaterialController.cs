using Jca.Sigmuni.Application.Dtos.General.TipoMateriales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class TipoMaterialController : ControllerBase
    {
        private readonly ITipoMaterialService _tipoMaterialService;

        public TipoMaterialController(ITipoMaterialService tipoMaterialService)
        {
            _tipoMaterialService = tipoMaterialService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoMaterialDto>> Get()
       => await _tipoMaterialService.FindAll();

    }
}
