using Jca.Sigmuni.Application.Dtos.General.EstadosAcabados;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class EstadoAcabadoController : ControllerBase
    {
        private readonly IEstadoAcabadoService _estadoAcabadoService;

        public EstadoAcabadoController(IEstadoAcabadoService estadoAcabadoService)
        {
            _estadoAcabadoService = estadoAcabadoService;
        }


        [HttpGet]
        public async Task<IEnumerable<EstadoAcabadoDto>> Get()
       => await _estadoAcabadoService.FindAll();

    }
}
