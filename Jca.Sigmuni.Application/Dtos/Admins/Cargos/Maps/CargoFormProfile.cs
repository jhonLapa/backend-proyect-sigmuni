using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.Admins.Cargos.Maps
{
    public class CargoFormProfile : Profile
    {
        public CargoFormProfile()
        {
            CreateMap<Domain.Admins.Cargo, CargoFormDto>().ReverseMap();
        }
    }
}