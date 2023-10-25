using Jca.Sigmuni.Application.Dtos.General.IntervencionInmuebles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class IntervencionInmueblesController : ControllerBase
    {
        private readonly IIntervencionInmueblesService _intervencionInmueblesService;

        public IntervencionInmueblesController(IIntervencionInmueblesService intervencionInmueblesService)
        {
            _intervencionInmueblesService = intervencionInmueblesService;
        }


        [HttpGet]
        public async Task<IEnumerable<IntervencionInmuebleDto>> Get()
       => await _intervencionInmueblesService.FindAll();

    }
}
