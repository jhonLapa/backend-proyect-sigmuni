using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.AfectacionesAntropicas.Maps
{
    public class AfectacionAntropicaProfile : Profile
    {
        public AfectacionAntropicaProfile()
        {
            CreateMap<AfectacionAntropica, AfectacionAntropicaDto>();
            CreateMap<AfectacionAntropica, AfectacionAntropicaDto>().ReverseMap();

            CreateMap<RequestPagination<AfectacionAntropica>, RequestPagination<AfectacionAntropicaDto>>().ReverseMap();
            CreateMap<ResponsePagination<AfectacionAntropica>, ResponsePagination<AfectacionAntropicaDto>>();
        }
    }
}
