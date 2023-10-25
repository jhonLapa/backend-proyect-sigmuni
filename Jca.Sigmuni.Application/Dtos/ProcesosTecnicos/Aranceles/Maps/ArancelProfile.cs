using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Aranceles.Maps
{
    public class ArancelProfile : Profile
    {
        public ArancelProfile()
        {
            CreateMap<Arancel, ArancelDto>()
                .AfterMap<ArancelProfileAction>();
            CreateMap<ArancelBusqueda, ArancelDto>().ReverseMap().AfterMap<ArancelProfileActionReverse>();

            CreateMap<RequestPagination<Arancel>, RequestPagination<ArancelDto>>().ReverseMap();
            CreateMap<RequestPagination<ArancelBusqueda>, RequestPagination<ArancelDto>>().ReverseMap();
            CreateMap<ResponsePagination<Arancel>, ResponsePagination<ArancelDto>>();
        }
    }
}
