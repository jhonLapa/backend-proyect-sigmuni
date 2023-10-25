using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions;
using Jca.Sigmuni.Application.Services.TramiteDocumentario.Implementations;
using Jca.Sigmuni.Core.Paginations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jca.Sigmuni.WebApi.Controllers.TramiteDocumentario
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ILogger<ProductoController> _logger;
        private readonly IProductoService _productoService;

        public ProductoController(ILogger<ProductoController> logger, IProductoService ProductoService)
        {
            _logger = logger;
            _productoService = ProductoService;
        }


        [HttpGet("ObtenerProducto/{idProducto}")]
        public async Task<ProductoDto> ObtenerCertificadoAsync(int idProducto)
        {
            var operacion = await _productoService.ObtenerAsync(idProducto);
            return operacion;
        }


        [HttpGet("ObtenerMaxRegistroCorrelativo/{flag}")]
        public async Task<ProductoDto> BuscarMaxRegistroCorrelativoAsyn(int flag)
        {
            var operacion = await _productoService.BuscarMaxRegistroCorrelativoAsyn(flag);
            return operacion;
        }

        [AllowAnonymous]

        [HttpPut("EstadoGeneradoProducto/{id}")]
        public async Task<ProductoDto> EstadoGeneradoProducto(int id)
        {
            var response = await _productoService.EstadoGeneradoProducto(id);
            return response;
        }
        [AllowAnonymous]

        [HttpGet("ObtenerProductoPorNumSolicitud/{numSolicitud}")]
        public async Task<ProductoDto> ObtenerCertificadPorNumSolicitudoAsync(string numSolicitud)
        {
            var operacion = await _productoService.ObtenerPorNumSolicitud(numSolicitud);
            return operacion;
        }


        [HttpPost("RegistrarProducto")]
        public async Task<ProductoRespuestaDto> CrearAsync(ProductoDto peticion)
        {
            var operacion = await _productoService.CrearAsync(peticion);
            return operacion;
        }



        [HttpPost("AdjuntarDocumentoProducto")]
        //[RequiereAcceso()]
        public async Task<bool> AdjuntarDocumentoProducto(ProductoDocumento peticion)
        {
            var operacion = await _productoService.AdjuntarDocumentoProducto(peticion);
            return operacion;
        }
        [AllowAnonymous]

        [HttpGet("PaginacionProducto")]
        public async Task<ResponsePagination<ProductoPaginadoDto>> PaginacionProducto([FromQuery] RequestPagination<ProductoPaginadoDto> request)
        => await _productoService.PaginatedSearch(request);



        [HttpPost("eliminarDocumentoProducto")]
        public async Task<bool> eliminarDocumentoProducto(ProductoDto peticion)
        {
            var operacion = await _productoService.eliminarDocumentoProducto(peticion);
            return operacion;
        }

        [AllowAnonymous]

        [HttpGet("PaginacionBusquedaProducto")]
        public async Task<ResponsePagination<ProductoInformeBusquedaDto>> PaginacionBusquedaProducto([FromQuery] RequestPagination<ProductoInformeBusquedaDto> request)
        => await _productoService.PaginacionProducto(request);
    }
}
