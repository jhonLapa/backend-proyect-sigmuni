using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoLitigantes.Maps
{
    public class TipoLitiganteProfile : Profile
    {
        public TipoLitiganteProfile()
        {
            CreateMap<TipoLitigante, TipoLitiganteDto>();
            CreateMap<TipoLitigante, TipoLitiganteDto>().ReverseMap();

            CreateMap<RequestPagination<TipoLitigante>, RequestPagination<TipoLitiganteDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoLitigante>, ResponsePagination<TipoLitiganteDto>>();
        }
    }
}
