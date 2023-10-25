using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TurnoInspeccions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoInspeccionController : ControllerBase
    {
        private readonly ITurnoInspeccionService _TurnoInspeccionService;

        public TurnoInspeccionController(ITurnoInspeccionService TurnoInspeccionService)
        {
            _TurnoInspeccionService = TurnoInspeccionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TurnoInspeccionDto>> Get()
       => await _TurnoInspeccionService.FindAll();


    }
}