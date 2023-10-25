using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas.Maps
{
    public class AreaActividadEconomicaProfile : Profile
    {
        public AreaActividadEconomicaProfile()
        {
            CreateMap<AreaActividadEconomica, AreaActividadEconomicaDto>();
            CreateMap<AreaActividadEconomica, AreaActividadEconomicaDto>().ReverseMap();

            CreateMap<RequestPagination<AreaActividadEconomica>, RequestPagination<AreaActividadEconomicaDto>>().ReverseMap();
            CreateMap<ResponsePagination<AreaActividadEconomica>, ResponsePagination<AreaActividadEconomicaDto>>();
        }
    }
}
