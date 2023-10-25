using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.MonumentosColoniales.Maps
{
    public class MonumentoColonialProfile : Profile
    {
        public MonumentoColonialProfile()
        {
            CreateMap<MonumentoColonial, MonumentoColonialDto>()
                .AfterMap<MonumentoColonialProfileAction>();
            CreateMap<MonumentoColonial, MonumentoColonialDto>().ReverseMap();

            CreateMap<RequestPagination<MonumentoColonial>, RequestPagination<MonumentoColonialDto>>().ReverseMap();
            CreateMap<ResponsePagination<MonumentoColonial>, ResponsePagination<MonumentoColonialDto>>();
        }
    }
}
