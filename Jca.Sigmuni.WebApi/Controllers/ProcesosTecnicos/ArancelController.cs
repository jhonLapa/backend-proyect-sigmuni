using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesosTecnicosCatastrales/[controller]")]
    [ApiController]
    public class ArancelController : ControllerBase
    {
        private readonly IArancelService _ArancelService;

        public ArancelController(
                    IArancelService ArancelService
                                     )
        {
            _ArancelService = ArancelService;
        }

        [HttpPost("Crear")]

        public async Task<bool> CrearAsync(ArancelDto peticion)
        {

            var operacion = await _ArancelService.CrearOActualizarAsync(peticion);
            return operacion;
        }

        [HttpPost("CrearMasivo")]

        public async Task<bool> CrearMasivoAsync(List<ArancelDto> peticion)
        {

            var operacion = await _ArancelService.CrearMasivoAsync(peticion);
            return operacion;
        }

        [HttpPut("Actualizar/{id}")]

        public async Task<bool> ActualizarAsync(int id, ArancelDto peticion)
        {

            peticion.IdArancel = id;
            var operacion = await _ArancelService.CrearOActualizarAsync(peticion);
            return operacion;
        }

        [HttpGet("Listar")]

        public async Task<List<ArancelDto>> FindAll()
        {
            var operacion = await _ArancelService.FindAll();
            return operacion;
        }



        [HttpGet("Obtener/{id}")]

        public async Task<ArancelDto> ObtenerAsync(int id)
        {
            var operacion = await _ArancelService.ObtenerAsync(id);
            return operacion;
        }

        [HttpDelete("Eliminar/{id}")]

        public async Task<bool> EliminarAsync(int id)
        {
            var operacion = await _ArancelService.EliminarAsync(id);
            return operacion;
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<ArancelDto>> PaginatedSearch([FromQuery] RequestPagination<ArancelDto> request)
         => await _ArancelService.PaginatedSearch(request);
    }
}
