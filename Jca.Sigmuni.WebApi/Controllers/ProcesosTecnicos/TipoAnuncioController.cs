using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class TipoAnuncioController : ControllerBase
    {
        private readonly ITipoAnuncioService _tipoAnuncioService;

        public TipoAnuncioController(ITipoAnuncioService tipoAnuncioService)
        {
            _tipoAnuncioService = tipoAnuncioService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoAnuncioDto>> Get()
       => await _tipoAnuncioService.FindAll();


    }
}
