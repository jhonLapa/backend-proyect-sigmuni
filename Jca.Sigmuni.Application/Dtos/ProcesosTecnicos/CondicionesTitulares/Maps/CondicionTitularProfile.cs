using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesTitulares.Maps
{
    public class CondicionTitularProfile : Profile
    {
        public CondicionTitularProfile()
        {
            CreateMap<CondicionTitular, CondicionTitularDto>();
            CreateMap<CondicionTitular, CondicionTitularDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionTitular>, RequestPagination<CondicionTitularDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionTitular>, ResponsePagination<CondicionTitularDto>>();
        }
    }
}
