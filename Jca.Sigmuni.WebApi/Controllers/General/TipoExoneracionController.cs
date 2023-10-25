using Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/general/[controller]")]
    [ApiController]
    public class TipoExoneracionController :ControllerBase
    {
        private readonly ITipoExoneracionService _tipoExoneracionService;
        public TipoExoneracionController(ITipoExoneracionService tipoExoneracionService)
        {
            _tipoExoneracionService = tipoExoneracionService;
        }

        [HttpGet]
        public async Task<IEnumerable<TipoExoneracionDto>>Get()
            => await _tipoExoneracionService.findAll();

    }
}
