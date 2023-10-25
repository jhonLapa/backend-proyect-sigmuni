using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CategoriaConstruccionController : ControllerBase
    {
        private readonly ICategoriaConstruccionService _categoriaConstruccionService;

        public CategoriaConstruccionController(ICategoriaConstruccionService categoriaConstruccionService)
        {
            _categoriaConstruccionService = categoriaConstruccionService;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoriaConstruccionDto>> Get()
       => await _categoriaConstruccionService.FindAll();

    }
}
