using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores.Maps
{
    public class CondicionConductorProfile : Profile
    {
        public CondicionConductorProfile()
        {
            CreateMap<CondicionConductor, CondicionConductorDto>();
            CreateMap<CondicionConductor, CondicionConductorDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionConductor>, RequestPagination<CondicionConductorDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionConductor>, ResponsePagination<CondicionConductorDto>>();
        }
    }
}
