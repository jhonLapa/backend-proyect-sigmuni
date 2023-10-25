using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Categorias;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/tramite_documentario/[controller]")]
    [ApiController]
    public class CategoriaController:Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        { 
            _categoriaService= categoriaService;    
        }

        [HttpGet]
        public async Task<IEnumerable<CategoriasDto>>Get()
            =>await _categoriaService.findAll();
    }
}
