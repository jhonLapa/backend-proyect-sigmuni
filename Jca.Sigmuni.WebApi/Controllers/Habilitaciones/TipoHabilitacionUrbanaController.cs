using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using Jca.Sigmuni.Application.Services.Habilitaciones.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Habilitaciones
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoHabilitacionUrbanaController : ControllerBase
    {
        private readonly ITipoHabilitacionUrbanaService _tipoHabilitacionUrbanaService;

        public TipoHabilitacionUrbanaController(ITipoHabilitacionUrbanaService tipoHabilitacionUrbanaService)
        {
            _tipoHabilitacionUrbanaService = tipoHabilitacionUrbanaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoHabilitacionUrbanaDto>> Get()
       => await _tipoHabilitacionUrbanaService.FindAll();


    }
}
