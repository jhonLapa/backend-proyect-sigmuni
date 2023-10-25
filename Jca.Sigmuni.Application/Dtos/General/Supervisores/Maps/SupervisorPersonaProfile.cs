using AutoMapper;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.Supervisores.Maps
{
    public class SupervisorPersonaProfile : Profile
    {
        public SupervisorPersonaProfile()
        {
            CreateMap<Persona, SupervisorPersonaDto>()
                .AfterMap<SupervisorPersonaProfileAction>();
        }
    }
}
