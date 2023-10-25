using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos.Maps
{
    public class RequisitoProfile : Profile
    {
        public RequisitoProfile()
        {
            CreateMap<Requisito, RequisitoDto>();
            CreateMap<Requisito, RequisitoDto>().ReverseMap();

            CreateMap<RequestPagination<Requisito>, RequestPagination<RequisitoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Requisito>, ResponsePagination<RequisitoDto>>();
        }
    }
    
}
