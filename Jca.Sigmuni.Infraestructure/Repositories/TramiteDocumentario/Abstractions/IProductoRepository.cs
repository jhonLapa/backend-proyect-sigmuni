using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.Core.Repositories;

namespace Jca.Sigmuni.Infraestructure.Repositories.TramiteDocumentario.Abstractions
{
    public interface IProductoRepository : IRepositoryPaginated<Producto>
    {
        Task<Producto> BuscarPorIdAsync(int id);
        Task<Producto> BuscarMaxCertificadoAsync(int flag);
        Task<Producto> BuscarMaxNumeroCorrelativoAsyn(int flag);
        Task<Producto> BuscarSolicitudRegistradaAsync(int idSolicitud);
        Task<Producto> BuscarPorNumeroCorrelativoAsync(string numCorrelativo, int flag);
        Task<Producto> ObtenerSolicitudPorNumSolicitud(string numSolicitud);
        Task<Producto?> Edit(int id, Producto entity);
        Task<Producto> Create(Producto entity);
        Task<Producto?> EstadoGeneradoProducto(int id);
        Task<ResponsePagination<ProductoInformeBusqueda>> PaginatedSearhProducto(RequestPagination<ProductoInformeBusqueda> entity);
    }
}
