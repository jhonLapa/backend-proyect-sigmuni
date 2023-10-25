using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    public class PersonaProfile : Profile
    {
        public PersonaProfile()
        {
            CreateMap<Persona, PersonaDto>().AfterMap<PersonaProfileAction>().ReverseMap();

            CreateMap<RequestPagination<Persona>, RequestPagination<PersonaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Persona>, ResponsePagination<PersonaDto>>();
        }
    }
}