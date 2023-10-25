using AutoMapper;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    public class PersonaFormProfile : Profile
    {
        public PersonaFormProfile()
        {
            CreateMap<Persona, PersonaFormDto>().ReverseMap();
        }
    }
}


