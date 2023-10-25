using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class EstadoLlenadoController : ControllerBase
    {
        private readonly IEstadoLlenadoService _estadoLlenadoService;

        public EstadoLlenadoController(IEstadoLlenadoService estadoLlenadoService)
        {
            _estadoLlenadoService = estadoLlenadoService;
        }


        [HttpGet]
        public async Task<IEnumerable<EstadoLlenadoDto>> Get()
       => await _estadoLlenadoService.FindAll();


    }
}
