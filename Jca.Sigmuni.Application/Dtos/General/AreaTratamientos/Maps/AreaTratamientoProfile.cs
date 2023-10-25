using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.AreaTratamientos.Maps
{
    public class AreaTratamientoProfile : Profile
    {
        public AreaTratamientoProfile()
        {
            CreateMap<AreaTratamiento, AreaTratamientoDto>();
            CreateMap<AreaTratamiento, AreaTratamientoDto>().ReverseMap();

            CreateMap<RequestPagination<AreaTratamiento>, RequestPagination<AreaTratamientoDto>>().ReverseMap();
            CreateMap<ResponsePagination<AreaTratamiento>, ResponsePagination<AreaTratamientoDto>>();
        }
    }
}
