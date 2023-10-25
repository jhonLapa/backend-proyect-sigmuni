using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.Admins.AreaCargos.Maps
{
    public class AreaCargoFormProfile : Profile
    {
        public AreaCargoFormProfile()
        {
            CreateMap<Domain.Admins.AreaCargo, AreaCargoFormDto>().ReverseMap();
        }
    }
}


