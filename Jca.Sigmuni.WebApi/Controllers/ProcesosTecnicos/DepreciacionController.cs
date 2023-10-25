using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.ProcesosTecnicos
{
    [Route("api/procesosTecnicosCatastrales/[controller]")]
    [ApiController]
    public class DepreciacionController : ControllerBase
    {
        private readonly IDepreciacionService _depreciacionService;

        public DepreciacionController(
                    IDepreciacionService depreciacionService
                                     )
        {
            _depreciacionService = depreciacionService;
        }

        [HttpPost("Crear")]
        
        public async Task<bool> CrearAsync(DepreciacionDto peticion)
        {
            
            var operacion = await _depreciacionService.CrearOActualizarAsync(peticion);
            return operacion;
        }

        [HttpPut("Actualizar/{id}")]
     
        public async Task<bool> ActualizarAsync(int id, DepreciacionDto peticion)
        {
            
            peticion.IdDepreciacion = id;
            var operacion = await _depreciacionService.CrearOActualizarAsync(peticion);
            return operacion;
        }

        [HttpGet("Listar")]
        
        public async Task<List<DepreciacionDto>> ListarAsync()
        {
            var operacion = await _depreciacionService.ListarGlobalAsync();
            return operacion;
        }

        [HttpPost("ListarPorFiltro")]
        
        public async Task<List<DepreciacionDto>> ListarAsync(DepreciacionDto peticion)
        {
            var operacion = await _depreciacionService.ListarFiltroAsync(peticion);
            return operacion;
        }

        [HttpGet("Obtener/{id}")]
       
        public async Task<DepreciacionDto> ObtenerAsync(int id)
        {
            var operacion = await _depreciacionService.ObtenerAsync(id);
            return operacion;
        }

        [HttpDelete("Eliminar/{id}")]
        
        public async Task<bool> EliminarAsync(int id)
        {
            var operacion = await _depreciacionService.EliminarAsync(id);
            return operacion;
        }

        [HttpGet("PaginatedSearch")]
        public async Task<ResponsePagination<DepreciacionDto>> PaginatedSearch([FromQuery] RequestPagination<DepreciacionDto> request)
         => await _depreciacionService.PaginatedSearch(request);
    }
}
