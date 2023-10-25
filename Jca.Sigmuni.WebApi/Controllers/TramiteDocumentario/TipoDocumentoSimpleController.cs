using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoSimples;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoSimpleController : ControllerBase
    {
        private readonly ITipoDocumentoSimpleService _TipoDocumentoSimpleService;

        public TipoDocumentoSimpleController(ITipoDocumentoSimpleService TipoDocumentoSimpleService)
        {
            _TipoDocumentoSimpleService = TipoDocumentoSimpleService;
        }


        [HttpGet]
        public async Task<IEnumerable<TipoDocumentoSimpleDto>> Get()
       => await _TipoDocumentoSimpleService.FindAll();


    }
}
