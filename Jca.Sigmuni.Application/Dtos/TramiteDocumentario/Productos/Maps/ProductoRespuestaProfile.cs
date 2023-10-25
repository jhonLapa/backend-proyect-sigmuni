using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Productos.Maps
{
    internal class ProductoRespuestaProfile : Profile
    {
        public ProductoRespuestaProfile()
        {
            CreateMap<Producto, ProductoRespuestaDto>()
                .AfterMap<ProductoRespuestaProfileAction>();


            CreateMap<RequestPagination<Producto>, RequestPagination<ProductoPaginadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Producto>, ResponsePagination<ProductoPaginadoDto>>();
        }
    }
}
