using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.Admins.Area.Maps
{
    public class AreaFormProfile : Profile
    {
        public AreaFormProfile()
        {
            CreateMap<Domain.Admins.Area, AreaFormDto>().ReverseMap();
        }
    }
}


