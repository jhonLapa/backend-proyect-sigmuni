using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps.Maps
{
    public class MepProfile : Profile
    {
        public MepProfile()
        {
            CreateMap<Mep, MepDto>();
            CreateMap<Mep, MepDto>().ReverseMap();

            CreateMap<RequestPagination<Mep>, RequestPagination<MepDto>>().ReverseMap();
            CreateMap<ResponsePagination<Mep>, ResponsePagination<MepDto>>();
        }
    }
}
