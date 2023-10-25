using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales.Maps
{
    public class BienCulturalProfile : Profile
    {
        public BienCulturalProfile()
        {
            CreateMap<Ficha, BienCulturalDto>()
                .AfterMap<BienCulturalProfileAction>();
        }
    }
}
