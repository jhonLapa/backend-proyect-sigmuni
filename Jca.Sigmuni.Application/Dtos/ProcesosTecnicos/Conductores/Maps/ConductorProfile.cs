using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores.Maps
{
    public class ConductorProfile : Profile
    {
        public ConductorProfile()
        {
            CreateMap<Persona, ConductorDto>();
            CreateMap<Persona, ConductorDto>().ReverseMap();

            CreateMap<RequestPagination<Persona>, RequestPagination<ConductorDto>>().ReverseMap();
            CreateMap<ResponsePagination<Persona>, ResponsePagination<ConductorDto>>();
        }
    }
}
