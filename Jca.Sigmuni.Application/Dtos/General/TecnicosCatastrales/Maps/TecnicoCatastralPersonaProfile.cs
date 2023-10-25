using AutoMapper;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales.Maps
{
    public class TecnicoCatastralPersonaProfile : Profile
    {
        public TecnicoCatastralPersonaProfile()
        {
            CreateMap<Persona, TecnicoCatastralPersonaDto>()
                .AfterMap<TecnicoCatastralPersonaProfileAction>();
        }
    }
}
