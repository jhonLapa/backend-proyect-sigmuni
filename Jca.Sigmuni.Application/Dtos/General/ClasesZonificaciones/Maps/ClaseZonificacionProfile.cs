using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Zonificaciones;

namespace Jca.Sigmuni.Application.Dtos.General.ClasesZonificaciones.Maps
{
    public class ClaseZonificacionProfile : Profile
    {
        public ClaseZonificacionProfile()
        {
            CreateMap<ClaseZonificacion, ClaseZonificacionDto>();
            CreateMap<ClaseZonificacion, ClaseZonificacionDto>().ReverseMap();

            CreateMap<RequestPagination<ClaseZonificacion>, RequestPagination<ClaseZonificacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<ClaseZonificacion>, ResponsePagination<ClaseZonificacionDto>>();
        }
    }
}
