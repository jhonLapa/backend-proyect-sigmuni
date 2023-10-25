using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDigitacions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDigitacionController : ControllerBase
    {
        private readonly ITipoDigitacionService _TipoDigitacionService;

        public TipoDigitacionController(ITipoDigitacionService TipoDigitacionService)
        {
            _TipoDigitacionService = TipoDigitacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDigitacionDto>> Get()
       => await _TipoDigitacionService.FindAll();


    }
}
