using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.Admins.AreaCargos.Maps
{
    public class AreaCargoProfile : Profile
    {
        public AreaCargoProfile()
        {
            CreateMap<Domain.Admins.AreaCargo, AreaCargoDto>();
            CreateMap<Domain.Admins.AreaCargo, AreaCargoDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.Admins.AreaCargo>, RequestPagination<AreaCargoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.Admins.AreaCargo>, ResponsePagination<AreaCargoDto>>();
        }
    }
}

