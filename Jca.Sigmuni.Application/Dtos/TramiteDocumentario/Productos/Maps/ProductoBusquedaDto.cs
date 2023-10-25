using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    public class ProductoBusquedaDto : Profile
    {
        public ProductoBusquedaDto()
        {
            CreateMap<ProductoInformeBusqueda, ProductoInformeBusquedaDto>();
            CreateMap<ProductoInformeBusqueda, ProductoInformeBusquedaDto>().ReverseMap();

            CreateMap<RequestPagination<ProductoInformeBusqueda>, RequestPagination<ProductoInformeBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<ProductoInformeBusqueda>, ResponsePagination<ProductoInformeBusquedaDto>>();
        }

    }
}