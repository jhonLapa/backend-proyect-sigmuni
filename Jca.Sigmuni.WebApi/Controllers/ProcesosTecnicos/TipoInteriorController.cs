using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoInteriorController : ControllerBase
    {
        private readonly ITipoInteriorService _tipoInteriorService;

        public TipoInteriorController(ITipoInteriorService tipoInteriorService)
        {
            _tipoInteriorService = tipoInteriorService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoInteriorDto>> Get()
       => await _tipoInteriorService.FindAll();


    }
}
