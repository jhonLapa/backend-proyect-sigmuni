using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones.Maps
{
    public class TipoInspeccionProfile : Profile
    {
        public TipoInspeccionProfile()
        {
            CreateMap<TipoInspeccion, TipoInspeccionDto>();
            CreateMap<TipoInspeccion, TipoInspeccionDto>().ReverseMap();

            CreateMap<RequestPagination<TipoInspeccion>, RequestPagination<TipoInspeccionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoInspeccion>, ResponsePagination<TipoInspeccionDto>>();
        }
    }
}
