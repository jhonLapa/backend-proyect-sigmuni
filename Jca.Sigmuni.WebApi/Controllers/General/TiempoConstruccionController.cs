using Jca.Sigmuni.Application.Dtos.General.TiemposConstrucciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TiempoConstruccionController : ControllerBase
    {
        private readonly ITiempoConstruccionService _tiempoConstruccionService;

        public TiempoConstruccionController(ITiempoConstruccionService tiempoConstruccionService)
        {
            _tiempoConstruccionService = tiempoConstruccionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TiempoConstruccionDto>> Get()
       => await _tiempoConstruccionService.FindAll();


    }
}
