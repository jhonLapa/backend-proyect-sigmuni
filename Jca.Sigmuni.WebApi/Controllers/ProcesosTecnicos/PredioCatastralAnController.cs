using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesos_tecnicos/[controller]")]
    [ApiController]
    public class PredioCatastralAnController : ControllerBase
    {
        private readonly IPredioCatastralAnService _predioCatastralAnService;

        public PredioCatastralAnController(IPredioCatastralAnService predioCatastralAnService)
        {
            _predioCatastralAnService = predioCatastralAnService;
        }


        [HttpGet]
        public async Task<IEnumerable<PredioCatastralAnDto>> Get()
       => await _predioCatastralAnService.FindAll();


    }
}
