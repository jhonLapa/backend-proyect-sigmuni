using Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes;
using Jca.Sigmuni.Application.Services.Jurisdicciones.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.Jurisdicciones
{
    [Route("api/jurisdiccion/[controller]")]
    [ApiController]
    public class JurisdiccionLoteController : ControllerBase
    {
        private readonly IJurisdiccionLoteService _JurisdiccionLoteService;

        public JurisdiccionLoteController(IJurisdiccionLoteService JurisdiccionLoteService)
        {
            _JurisdiccionLoteService = JurisdiccionLoteService;
        }


        [HttpGet]
        public async Task<IEnumerable<JurisdiccionLoteDto>> Get()
       => await _JurisdiccionLoteService.FindAll();

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<JurisdiccionLoteDto>> PaginatedSearch([FromQuery] RequestPagination<JurisdiccionLoteDto> request)
         => await _JurisdiccionLoteService.PaginatedSearch(request);
    }
}
