using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    public class ProductoProfile : Profile
    {
        public ProductoProfile()
        {
            CreateMap<Producto, ProductoDto>()
                .AfterMap<ProductoProfileAction>();

            CreateMap<Producto, ProductoPaginadoDto>()
             .AfterMap<ProductoPaginadoProfileAction>();
        }
    }
}