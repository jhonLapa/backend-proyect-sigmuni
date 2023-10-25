using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Habilitaciones;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas.Maps
{
    public class HabilitacionUrbanaBusquedaProfile : Profile
    {
        public HabilitacionUrbanaBusquedaProfile()
        {
            CreateMap<HabilitacionUrbana, HabilitacionUrbanaBusquedaDto>()
               .AfterMap<HabilitacionUrbanaBusquedaProfileAction>();
            CreateMap<HabilitacionUrbana, HabilitacionUrbanaBusquedaDto>().ReverseMap();

            CreateMap<RequestPagination<HabilitacionUrbana>, RequestPagination<HabilitacionUrbanaBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<HabilitacionUrbana>, ResponsePagination<HabilitacionUrbanaBusquedaDto>>();
        }
    }
}
