using Jca.Sigmuni.Application.Dtos.General.IntervencionesConservaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class IntervencionConservacionController : ControllerBase
    {
        private readonly IIntervencionConservacionService _intervencionConservacionService;

        public IntervencionConservacionController(IIntervencionConservacionService intervencionConservacionService)
        {
            _intervencionConservacionService = intervencionConservacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<IntervencionConservacionDto>> Get()
       => await _intervencionConservacionService.FindAll();

    }
}
