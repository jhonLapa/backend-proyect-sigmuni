using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioPagos;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioPagoController : ControllerBase
    {
        private readonly IMedioPagoService _MedioPagoService;

        public MedioPagoController(IMedioPagoService MedioPagoService)
        {
            _MedioPagoService = MedioPagoService;
        }


        [HttpGet]
        public async Task<IEnumerable<MedioPagoDto>> Get()
       => await _MedioPagoService.FindAll();


    }
}
