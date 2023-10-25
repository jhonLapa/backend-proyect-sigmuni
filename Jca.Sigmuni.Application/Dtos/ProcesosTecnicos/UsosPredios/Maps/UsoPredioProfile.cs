using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios.Maps
{
    public class UsoPredioProfile : Profile
    {
        public UsoPredioProfile()
        {
            CreateMap<UsoPredio, UsoPredioDto>();
            CreateMap<UsoPredio, UsoPredioDto>().ReverseMap();

            CreateMap<RequestPagination<UsoPredio>, RequestPagination<UsoPredioDto>>().ReverseMap();
            CreateMap<ResponsePagination<UsoPredio>, ResponsePagination<UsoPredioDto>>();
        }
    }
}
