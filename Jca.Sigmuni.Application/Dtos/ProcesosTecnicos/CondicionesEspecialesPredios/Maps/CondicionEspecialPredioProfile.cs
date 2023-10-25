using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesEspecialesPredios.Maps
{
    public class CondicionEspecialPredioProfile : Profile
    {
        public CondicionEspecialPredioProfile()
        {
            CreateMap<CondicionEspecialPredio, CondicionEspecialPredioDto>();
            CreateMap<CondicionEspecialPredio, CondicionEspecialPredioDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionEspecialPredio>, RequestPagination<CondicionEspecialPredioDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionEspecialPredio>, ResponsePagination<CondicionEspecialPredioDto>>();
        }
    }
}
