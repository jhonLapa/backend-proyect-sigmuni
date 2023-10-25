using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.MedioRegistros;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedioRegistroController : ControllerBase
    {
        private readonly IMedioRegistroService _MedioRegistroService;

        public MedioRegistroController(IMedioRegistroService MedioRegistroService)
        {
            _MedioRegistroService = MedioRegistroService;
        }


        [HttpGet]
        public async Task<IEnumerable<MedioRegistroDto>> Get()
       => await _MedioRegistroService.FindAll();


    }
}