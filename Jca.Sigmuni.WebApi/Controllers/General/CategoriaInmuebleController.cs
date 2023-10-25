using Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CategoriaInmuebleController : ControllerBase
    {
        private readonly ICategoriaInmuebleService _categoriaInmuebleService;

        public CategoriaInmuebleController(ICategoriaInmuebleService categoriaInmuebleService)
        {
            _categoriaInmuebleService = categoriaInmuebleService;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoriaInmuebleDto>> Get()
       => await _categoriaInmuebleService.FindAll();

    }
}
