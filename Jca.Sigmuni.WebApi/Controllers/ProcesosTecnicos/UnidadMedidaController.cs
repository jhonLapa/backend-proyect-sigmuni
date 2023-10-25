using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class UnidadMedidaController : ControllerBase
    {
        private readonly IUnidadMedidaService _unidadMedidaService;

        public UnidadMedidaController(IUnidadMedidaService unidadMedidaService)
        {
            _unidadMedidaService = unidadMedidaService;
        }


        [HttpGet]
        public async Task<IEnumerable<UnidadMedidaDto>> Get()
       => await _unidadMedidaService.FindAll();


    }
}
