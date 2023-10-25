using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Zonificaciones;

namespace Jca.Sigmuni.Application.Dtos.Zonificaciones.ZonificacionesParametros.Maps
{
    public class ZonificacionParametroProfile : Profile
    {
        public ZonificacionParametroProfile()
        {
            CreateMap<ZonificacionParametro, ZonificacionParametroDto>()
                .AfterMap<ZonificacionParametroProfileAction>();
            CreateMap<ZonificacionParametro, ZonificacionParametroDto>().ReverseMap();

            CreateMap<RequestPagination<ZonificacionParametro>, RequestPagination<ZonificacionParametroDto>>().ReverseMap();
            CreateMap<ResponsePagination<ZonificacionParametro>, ResponsePagination<ZonificacionParametroDto>>();
        }
    }
}
