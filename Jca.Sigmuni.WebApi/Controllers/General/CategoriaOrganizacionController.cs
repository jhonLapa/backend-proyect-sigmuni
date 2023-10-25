using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class CategoriaOrganizacionController : ControllerBase
    {
        private readonly ICategoriaOrganizacionService _categoriaOrganizacionService;

        public CategoriaOrganizacionController(ICategoriaOrganizacionService categoriaOrganizacionService)
        {
            _categoriaOrganizacionService = categoriaOrganizacionService;
        }


        [HttpGet]
        public async Task<IEnumerable<CategoriaOrganizacionDto>> Get()
       => await _categoriaOrganizacionService.FindAll();

    }
}
