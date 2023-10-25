using Jca.Sigmuni.Application.Dtos.General.Motivos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotivoController : ControllerBase
    {
        private readonly IMotivoService _MotivoService;

        public MotivoController(IMotivoService MotivoService)
        {
            _MotivoService = MotivoService;
        }


        [HttpGet]
        public async Task<IEnumerable<MotivoDto>> Get()
       => await _MotivoService.FindAll();


    }
}
