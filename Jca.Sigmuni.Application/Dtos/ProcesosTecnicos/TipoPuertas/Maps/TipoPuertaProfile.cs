using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas.Maps
{
    public class TipoPuertaProfile : Profile
    {
        public TipoPuertaProfile()
        {
            CreateMap<TipoPuerta, TipoPuertaDto>();
            CreateMap<TipoPuerta, TipoPuertaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoPuerta>, RequestPagination<TipoPuertaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoPuerta>, ResponsePagination<TipoPuertaDto>>();
        }
    }
}
