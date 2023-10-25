using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoPuertaController : ControllerBase
    {
        private readonly ITipoPuertaService _tipoPuertaService;

        public TipoPuertaController(ITipoPuertaService tipoPuertaService)
        {
            _tipoPuertaService = tipoPuertaService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoPuertaDto>> Get()
       => await _tipoPuertaService.FindAll();


    }
}
