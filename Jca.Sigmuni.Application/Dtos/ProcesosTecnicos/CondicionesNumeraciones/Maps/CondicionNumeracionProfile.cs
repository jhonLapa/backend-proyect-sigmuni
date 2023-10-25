using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones.Maps
{
    public class CondicionNumeracionProfile : Profile
    {
        public CondicionNumeracionProfile()
        {
            CreateMap<CondicionNumeracion, CondicionNumeracionDto>();
            CreateMap<CondicionNumeracion, CondicionNumeracionDto>().ReverseMap();

            CreateMap<RequestPagination<CondicionNumeracion>, RequestPagination<CondicionNumeracionDto>>().ReverseMap();
            CreateMap<ResponsePagination<CondicionNumeracion>, ResponsePagination<CondicionNumeracionDto>>();
        }
    }
}
