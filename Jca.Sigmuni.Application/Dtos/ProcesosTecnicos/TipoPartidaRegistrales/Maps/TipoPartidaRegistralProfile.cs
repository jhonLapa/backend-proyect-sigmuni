using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales.Maps
{
    public class TipoPartidaRegistralProfile : Profile
    {
        public TipoPartidaRegistralProfile()
        {
            CreateMap<TipoPartidaRegistral, TipoPartidaRegistralDto>();
            CreateMap<TipoPartidaRegistral, TipoPartidaRegistralDto>().ReverseMap();

            CreateMap<RequestPagination<TipoPartidaRegistral>, RequestPagination<TipoPartidaRegistralDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoPartidaRegistral>, ResponsePagination<TipoPartidaRegistralDto>>();
        }
    }
}
