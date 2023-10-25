using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBienesCulturales.Maps
{
    public class FichaBienCulturalProfile : Profile
    {
        public FichaBienCulturalProfile()
        {
            CreateMap<FichaBienCultural, FichaBienCulturalDto>();
            CreateMap<FichaBienCultural, FichaBienCulturalDto>().ReverseMap();

            CreateMap<RequestPagination<FichaBienCultural>, RequestPagination<FichaBienCulturalDto>>().ReverseMap();
            CreateMap<ResponsePagination<FichaBienCultural>, ResponsePagination<FichaBienCulturalDto>>();
        }
    }
}
