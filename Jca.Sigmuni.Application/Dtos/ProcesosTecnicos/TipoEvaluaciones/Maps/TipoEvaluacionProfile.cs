using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEvaluaciones.Maps
{
    public class TipoEvaluacionProfile : Profile
    {
        public TipoEvaluacionProfile()
        {
            CreateMap<TipoEvaluacion, TipoEvaluacionDto>();
            CreateMap<TipoEvaluacion, TipoEvaluacionDto>().ReverseMap();

            CreateMap<RequestPagination<TipoEvaluacion>, RequestPagination<TipoEvaluacionDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoEvaluacion>, ResponsePagination<TipoEvaluacionDto>>();
        }
    }
}
