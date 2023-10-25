using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios.Maps
{
    public class InfoComplementarioProfile : Profile
    {
        public InfoComplementarioProfile()
        {
            CreateMap<InfoComplementario, InfoComplementarioDto>()
                .AfterMap<InfoComplemetarioProfileAction>();
            CreateMap<InfoComplementario, InfoComplementarioDto>().ReverseMap();

            CreateMap<RequestPagination<InfoComplementario>, RequestPagination<InfoComplementarioDto>>().ReverseMap();
            CreateMap<ResponsePagination<InfoComplementario>, ResponsePagination<InfoComplementarioDto>>();
        }
    }
}
