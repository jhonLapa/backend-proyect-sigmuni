using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.GirosAutorizados;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class GiroAutorizadoController : ControllerBase
    {
        private readonly IGiroAutorizadoService _giroAutorizadoService;

        public GiroAutorizadoController(IGiroAutorizadoService giroAutorizadoService)
        {
            _giroAutorizadoService = giroAutorizadoService;
        }


        [HttpGet]
        public async Task<IEnumerable<GiroAutorizadoDto>> Get()
       => await _giroAutorizadoService.FindAll();

        
    }
}
