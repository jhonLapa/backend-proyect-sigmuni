using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales.Maps
{
    public class NormaIntMonColonialProfile : Profile
    {
        public NormaIntMonColonialProfile()
        {
            CreateMap<NormaIntMonColonial, NormaIntMonColonialDto>();
            CreateMap<NormaIntMonColonial, NormaIntMonColonialDto>().ReverseMap();

            CreateMap<RequestPagination<NormaIntMonColonial>, RequestPagination<NormaIntMonColonialDto>>().ReverseMap();
            CreateMap<ResponsePagination<NormaIntMonColonial>, ResponsePagination<NormaIntMonColonialDto>>();
        }
    }
}
