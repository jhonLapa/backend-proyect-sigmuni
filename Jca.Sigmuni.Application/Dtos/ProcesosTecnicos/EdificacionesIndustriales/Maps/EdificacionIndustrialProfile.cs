using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales.Maps
{
    public class EdificacionIndustrialProfile : Profile
    {
        public EdificacionIndustrialProfile()
        {
            CreateMap<EdificacionIndustrial, EdificacionIndustrialDto>();
            CreateMap<EdificacionIndustrial, EdificacionIndustrialDto>().ReverseMap();

            CreateMap<RequestPagination<EdificacionIndustrial>, RequestPagination<EdificacionIndustrialDto>>().ReverseMap();
            CreateMap<ResponsePagination<EdificacionIndustrial>, ResponsePagination<EdificacionIndustrialDto>>();
        }
    }
}
