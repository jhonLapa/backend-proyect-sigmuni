using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios.Maps
{
    public class DomicilioProfile : Profile
    {
        public DomicilioProfile() 
        {
            CreateMap<Domicilio, DomicilioDto>();
            CreateMap<Domicilio, DomicilioDto>().ReverseMap();

            CreateMap<RequestPagination<Domicilio>, RequestPagination<DomicilioDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domicilio>, ResponsePagination<DomicilioDto>>();
        }
    }
}
