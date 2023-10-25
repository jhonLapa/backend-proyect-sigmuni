using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.General.EstadoCivil.Maps
{
    public class EstadoCivilFormProfile : Profile
    {
        public EstadoCivilFormProfile()
        {
            CreateMap<Domain.General.EstadoCivil, EstadoCivilFormDto>().ReverseMap();
        }
    }
}