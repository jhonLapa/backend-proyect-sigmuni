using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores.Map
{
    public class DomicilioConductorProfile : Profile
    {
        public DomicilioConductorProfile()
        {
            CreateMap<Domicilio, DomicilioConductorDto>()
                .AfterMap<DomicilioConductorProfileAction>();
            CreateMap<Domicilio, DomicilioConductorDto>().ReverseMap();

            CreateMap<RequestPagination<Domicilio>, RequestPagination<DomicilioConductorDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domicilio>, ResponsePagination<DomicilioConductorDto>>();
        }
    }
}
