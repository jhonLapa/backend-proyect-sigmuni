using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class CotitularProfile : Profile
    {
        public CotitularProfile()
        {
            CreateMap<Ficha, FichaCotitularDto>()
                .AfterMap<CotitularProfileAction>();
        }
    }
}
