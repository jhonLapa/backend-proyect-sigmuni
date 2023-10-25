using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Uits.Maps
{
    public class UitProfile : Profile
    {
        public UitProfile()
        {
            CreateMap<Uit, UitDto>();
            CreateMap<Uit, UitDto>().ReverseMap();

            CreateMap<RequestPagination<Uit>, RequestPagination<UitDto>>().ReverseMap();
            CreateMap<ResponsePagination<Uit>, ResponsePagination<UitDto>>();
        }
    }
}