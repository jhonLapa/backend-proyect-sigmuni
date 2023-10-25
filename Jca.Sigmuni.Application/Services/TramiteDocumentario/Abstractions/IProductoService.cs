using Jca.Sigmuni.Application.Core.Services;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Services.TramiteDocumentario.Abstractions
{
    public interface IProductoService : IServicePaginated<ProductoPaginadoDto>
    {
        Task<ProductoRespuestaDto> CrearAsync(ProductoDto peticion);
        Task<ProductoDto> BuscarMaxRegistroCorrelativoAsyn(int flag);
        Task<ProductoDto> ObtenerAsync(int idProducto);
        Task<ProductoDto> ObtenerPorNumSolicitud(string numSolicitud);
        Task<ProductoDto?> EstadoGeneradoProducto(int id);
        Task<bool> AdjuntarDocumentoProducto(ProductoDocumento peticion);

        Task<bool> eliminarDocumentoProducto(ProductoDto peticion);
        Task<ResponsePagination<ProductoInformeBusquedaDto>> PaginacionProducto(RequestPagination<ProductoInformeBusquedaDto> dto);

    }
}
