using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.AreaCargos;

namespace Jca.Sigmuni.Application.Dtos.Admins.Menu.Maps
{
    public class MenuFormProfile : Profile
    {
        public MenuFormProfile()
        {
            CreateMap<Domain.Admins.Menu, MenuFormDto>().ReverseMap();
        }
    }
}
