using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionAnuncios.Maps
{
    public class CondicionAnuncioProfile : Profile
    {
        public CondicionAnuncioProfile()
        {
            CreateMap<CondicionAnuncio, CondicionAnuncioDto>();
            CreateMap<CondicionAnuncio, CondicionAnuncioDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionAnuncio>, RequestPagination<CondicionAnuncioDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionAnuncio>, ResponsePagination<CondicionAnuncioDto>>();
        }
    }
}
