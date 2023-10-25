using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.CondicionEspecialTitulares.Maps
{
    public class CondicionEspecialTitularProfile : Profile
    {
        public CondicionEspecialTitularProfile()
        {
            CreateMap<CondicionEspecialTitular, CondicionEspecialTitularDto>();
            CreateMap<CondicionEspecialTitular, CondicionEspecialTitularDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionEspecialTitular>, RequestPagination<CondicionEspecialTitularDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionEspecialTitular>, ResponsePagination<CondicionEspecialTitularDto>>();
        }
    }
}
