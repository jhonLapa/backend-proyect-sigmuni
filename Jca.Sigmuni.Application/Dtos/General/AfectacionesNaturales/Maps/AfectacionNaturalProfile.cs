using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.AfectacionesNaturales.Maps
{
    public class AfectacionNaturalProfile : Profile
    {
        public AfectacionNaturalProfile()
        {
            CreateMap<AfectacionNatural, AfectacionNaturalDto>();
            CreateMap<AfectacionNatural, AfectacionNaturalDto>().ReverseMap();

            CreateMap<RequestPagination<AfectacionNatural>, RequestPagination<AfectacionNaturalDto>>().ReverseMap();
            CreateMap<ResponsePagination<AfectacionNatural>, ResponsePagination<AfectacionNaturalDto>>();
        }
    }
}
