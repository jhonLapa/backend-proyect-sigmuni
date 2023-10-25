using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas.Maps
{
    public class PuertaProfile : Profile
    {
        public PuertaProfile()
        {
            CreateMap<Puerta, PuertaDto>()
                .AfterMap<PuertaProfileAction>();
            CreateMap<Puerta, PuertaDto>().ReverseMap();

            CreateMap<RequestPagination<Puerta>, RequestPagination<PuertaDto>>().ReverseMap();
            CreateMap<ResponsePagination<Puerta>, ResponsePagination<PuertaDto>>();
        }
    }
}
