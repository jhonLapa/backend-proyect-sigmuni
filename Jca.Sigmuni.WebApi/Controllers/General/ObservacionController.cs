using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class ObservacionController : ControllerBase
    {
        private readonly IObservacionService _observacionService;

        public ObservacionController(IObservacionService observacionService)
        {
            _observacionService = observacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<ObservacionDto>> Get()
       => await _observacionService.FindAll();


    }
}
