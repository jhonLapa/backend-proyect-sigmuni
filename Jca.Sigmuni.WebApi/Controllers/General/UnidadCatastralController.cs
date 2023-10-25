using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class UnidadCatastralController : ControllerBase
    {
        private readonly IUnidadCatastralService _unidadCatastralService;

        public UnidadCatastralController(IUnidadCatastralService unidadCatastralService)
        {
            _unidadCatastralService = unidadCatastralService;
        }


        [HttpGet]
        public async Task<IEnumerable<UnidadCatastralDto>> Get()
       => await _unidadCatastralService.FindAll();


    }
}
