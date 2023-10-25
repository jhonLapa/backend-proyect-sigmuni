using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Resultados;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultadoController : ControllerBase
    {
        private readonly IResultadoService _ResultadoService;

        public ResultadoController(IResultadoService ResultadoService)
        {
            _ResultadoService = ResultadoService;
        }


        [HttpGet]
        public async Task<IEnumerable<ResultadoDto>> Get()
       => await _ResultadoService.FindAll();


    }
}
