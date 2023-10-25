using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.Admins.Menu.Maps
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<Domain.Admins.Menu, MenuDto>();
            CreateMap<Domain.Admins.Menu, MenuDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.Admins.Menu>, RequestPagination<MenuDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.Admins.Menu>, ResponsePagination<MenuDto>>();
        }
    }
}
