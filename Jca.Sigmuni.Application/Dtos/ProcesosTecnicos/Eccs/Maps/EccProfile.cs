using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs.Maps
{
    public class EccProfile : Profile
    {
        public EccProfile()
        {
            CreateMap<Ecc, EccDto>();
            CreateMap<Ecc, EccDto>().ReverseMap();

            CreateMap<RequestPagination<Ecc>, RequestPagination<EccDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ecc>, ResponsePagination<EccDto>>();
        }
    }
}
