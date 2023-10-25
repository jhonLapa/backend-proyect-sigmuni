using AutoMapper;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios.Maps
{
    public class DomicilioFormProfile : Profile
    {
        public DomicilioFormProfile() 
        {
            CreateMap<Domicilio, DomicilioFormDto>().ReverseMap();
        }
    }
}
