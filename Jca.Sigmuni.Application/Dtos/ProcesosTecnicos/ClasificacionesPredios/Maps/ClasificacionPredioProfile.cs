using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios.Maps
{
    public class ClasificacionPredioProfile : Profile
    {
        public ClasificacionPredioProfile()
        {
            CreateMap<ClasificacionPredio, ClasificacionPredioDto>();
            CreateMap<ClasificacionPredio, ClasificacionPredioDto>().ReverseMap();

            CreateMap<RequestPagination<ClasificacionPredio>, RequestPagination<ClasificacionPredioDto>>().ReverseMap();
            CreateMap<ResponsePagination<ClasificacionPredio>, ResponsePagination<ClasificacionPredioDto>>();
        }
    }
}
