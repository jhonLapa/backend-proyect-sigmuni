using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos.Maps
{
    public class TipoMantenimientoProfile : Profile
    {
        public TipoMantenimientoProfile()
        {
            CreateMap<TipoMantenimiento, TipoMantenimientoDto>();
            CreateMap<TipoMantenimiento, TipoMantenimientoDto>().ReverseMap();

            CreateMap<RequestPagination<TipoMantenimiento>, RequestPagination<TipoMantenimientoDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoMantenimiento>, ResponsePagination<TipoMantenimientoDto>>();
        }
    }
}
