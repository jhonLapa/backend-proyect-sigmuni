using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.RepresentantesConductores.Maps
{
    public class RepresentanteConductorProfile : Profile
    {
        public RepresentanteConductorProfile()
        {
            CreateMap<Persona, RepresentanteConductorDto>();
            CreateMap<Persona, RepresentanteConductorDto>().ReverseMap();

            CreateMap<RequestPagination<Persona>, RequestPagination<RepresentanteConductorDto>>().ReverseMap();
            CreateMap<ResponsePagination<Persona>, ResponsePagination<RepresentanteConductorDto>>();
        }
    }
}
