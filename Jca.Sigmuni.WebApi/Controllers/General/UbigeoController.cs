using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.General
{
    [Route("api/busquedas/[controller]")]
    [ApiController]
    public class UbigeoController : ControllerBase
    {
        private readonly IUbigeoService _ubigeoService;

        public UbigeoController(IUbigeoService ubigeoService)
        {
            _ubigeoService = ubigeoService;
        }


        [HttpGet]
        public async Task<IEnumerable<UbigeoDto>> Get()
       => await _ubigeoService.FindAll();

        [HttpGet("listarPorCodigo/{codigo}")]
        public async Task<IEnumerable<UbigeoDto>> listarPorCodigo(string codigo)
            => await _ubigeoService.listarPorCodigo(codigo);

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<UbigeoDto>> PaginatedSearch([FromQuery] RequestPagination<UbigeoDto> request)
        => await _ubigeoService.PaginatedSearch(request);
    }
}
