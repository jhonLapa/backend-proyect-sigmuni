using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class PuertaController : ControllerBase
    {
        private readonly IPuertaService _puertaService;

        public PuertaController(IPuertaService puertaService)
        {
            _puertaService = puertaService;
        }


        [HttpGet]
        public async Task<IEnumerable<PuertaDto>> Get()
       => await _puertaService.FindAll();


    }
}
