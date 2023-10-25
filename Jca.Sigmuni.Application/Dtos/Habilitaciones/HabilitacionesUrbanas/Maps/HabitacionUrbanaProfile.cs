using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Habilitaciones;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionesUrbanas.Maps
{
    public class HabitacionUrbanaProfile : Profile
    {
        public HabitacionUrbanaProfile()
        {
            CreateMap<HabilitacionUrbana, HabilitacionUrbanaDto>()
               .AfterMap<HabilitacionUrbanaProfileAction>();
            CreateMap<HabilitacionUrbana, HabilitacionUrbanaDto>().ReverseMap();

            CreateMap<RequestPagination<HabilitacionUrbana>, RequestPagination<HabilitacionUrbanaDto>>().ReverseMap();
            CreateMap<ResponsePagination<HabilitacionUrbana>, ResponsePagination<HabilitacionUrbanaDto>>();
        }
    }
}
