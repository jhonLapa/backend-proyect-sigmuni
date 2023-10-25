using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas.Maps
{
    public class ActividadEconomicaProfile : Profile
    {
        public ActividadEconomicaProfile()
        {
            CreateMap<Ficha, ActividadEconomicaDto>()
                .AfterMap<ActividadEconomicaProfileAction>();
        }
    }
}
