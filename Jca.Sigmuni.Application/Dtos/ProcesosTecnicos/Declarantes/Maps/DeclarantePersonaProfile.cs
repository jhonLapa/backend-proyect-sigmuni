using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes.Maps
{
    public class DeclarantePersonaProfile : Profile
    {
        public DeclarantePersonaProfile()
        {
            CreateMap<Persona, DeclarantePersonaDto>()
                .AfterMap<DeclarantePersonaProfileAction>();
        }
    }
}
