using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoLitigantes;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoLitiganteController : ControllerBase
    {
        private readonly ITipoLitiganteService _tipoLitiganteService;

        public TipoLitiganteController(ITipoLitiganteService tipoLitiganteService)
        {
            _tipoLitiganteService = tipoLitiganteService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoLitiganteDto>> Get()
       => await _tipoLitiganteService.FindAll();


    }
}
