using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos.Maps
{
    public class TipoServicioBasicoProfile : Profile
    {
        public TipoServicioBasicoProfile()
        {
            CreateMap<TipoServicioBasico, TipoServicioBasicoDto>();
            CreateMap<TipoServicioBasico, TipoServicioBasicoDto>().ReverseMap();

            CreateMap<RequestPagination<TipoServicioBasico>, RequestPagination<TipoServicioBasicoDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoServicioBasico>, ResponsePagination<TipoServicioBasicoDto>>();
        }
    }
}
