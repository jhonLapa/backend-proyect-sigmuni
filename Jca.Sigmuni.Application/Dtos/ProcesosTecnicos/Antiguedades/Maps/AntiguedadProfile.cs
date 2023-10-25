using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades.Maps
{
    public class AntiguedadProfile : Profile
    {
        public AntiguedadProfile()
        {
            CreateMap<Antiguedad, AntiguedadDto>();
            CreateMap<Antiguedad, AntiguedadDto>().ReverseMap();

            CreateMap<RequestPagination<Antiguedad>, RequestPagination<AntiguedadDto>>().ReverseMap();
            CreateMap<ResponsePagination<Antiguedad>, ResponsePagination<AntiguedadDto>>();
        }
    }
}
