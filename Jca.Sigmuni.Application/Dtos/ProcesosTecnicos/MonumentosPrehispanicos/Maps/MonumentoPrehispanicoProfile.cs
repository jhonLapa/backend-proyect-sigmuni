using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosPrehispanicos.Maps
{
    public class MonumentoPrehispanicoProfile : Profile
    {
        public MonumentoPrehispanicoProfile()
        {
            CreateMap<MonumentoPrehispanico, MonumentoPrehispanicoDto>();
            CreateMap<MonumentoPrehispanico, MonumentoPrehispanicoDto>().ReverseMap();

            CreateMap<RequestPagination<MonumentoPrehispanico>, RequestPagination<MonumentoPrehispanicoDto>>().ReverseMap();
            CreateMap<ResponsePagination<MonumentoPrehispanico>, ResponsePagination<MonumentoPrehispanicoDto>>();
        }
    }
}
