using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.Admins.Area.Maps
{
    public class AreaProfile : Profile
    {
        public AreaProfile()
        {
            CreateMap<Domain.Admins.Area, AreaDto>();
            CreateMap<Domain.Admins.Area, AreaDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.Admins.Area>, RequestPagination<AreaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.Admins.Area>, ResponsePagination<AreaDto>>();
        }
    }
}

