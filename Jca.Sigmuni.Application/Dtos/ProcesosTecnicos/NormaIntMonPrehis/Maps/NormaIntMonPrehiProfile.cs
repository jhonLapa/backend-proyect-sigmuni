using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins.Maps
{
    public class NormaIntMonPrehiProfile : Profile
    {
        public NormaIntMonPrehiProfile()
        {
            CreateMap<NormaIntMonPrehi, NormaIntMonPrehiDto>();
            CreateMap<NormaIntMonPrehi, NormaIntMonPrehiDto>().ReverseMap();

            CreateMap<RequestPagination<NormaIntMonPrehi>, RequestPagination<NormaIntMonPrehiDto>>().ReverseMap();
            CreateMap<ResponsePagination<NormaIntMonPrehi>, ResponsePagination<NormaIntMonPrehiDto>>();
        }
    }
}
