using Jca.Sigmuni.Application.Dtos.General.ElementosArquitectonicos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class ElementoArquitectonicoController : ControllerBase
    {
        private readonly IElementoArquitectonicoService _elementoArquitectonicoService;

        public ElementoArquitectonicoController(IElementoArquitectonicoService elementoArquitectonicoService)
        {
            _elementoArquitectonicoService = elementoArquitectonicoService;
        }


        [HttpGet]
        public async Task<IEnumerable<ElementoArquitectonicoDto>> Get()
       => await _elementoArquitectonicoService.FindAll();

    }
}
