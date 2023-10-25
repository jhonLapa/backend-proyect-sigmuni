using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Monedas;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonedaController : ControllerBase
    {
        private readonly IMonedaService _MonedaService;

        public MonedaController(IMonedaService MonedaService)
        {
            _MonedaService = MonedaService;
        }


        [HttpGet]
        public async Task<IEnumerable<MonedaDto>> Get()
       => await _MonedaService.FindAll();


    }
}
