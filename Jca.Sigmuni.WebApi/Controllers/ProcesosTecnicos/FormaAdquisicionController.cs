using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FormaAdquisiciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class FormaAdquisicionController : ControllerBase
    {
        private readonly IFormaAdquisicionService _formaAdquisicionService;

        public FormaAdquisicionController(IFormaAdquisicionService formaAdquisicionService)
        {
            _formaAdquisicionService = formaAdquisicionService;
        }


        [HttpGet]
        public async Task<IEnumerable<FormaAdquisicionDto>> Get()
       => await _formaAdquisicionService.FindAll();


    }
}
