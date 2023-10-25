using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.GirosAutorizados.Maps
{
    public class GiroAutorizadoProfile : Profile
    {
        public GiroAutorizadoProfile()
        {
            CreateMap<GiroAutorizado, GiroAutorizadoDto>();
            CreateMap<GiroAutorizado, GiroAutorizadoDto>().ReverseMap();

            CreateMap<RequestPagination<GiroAutorizado>, RequestPagination<GiroAutorizadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<GiroAutorizado>, ResponsePagination<GiroAutorizadoDto>>();
        }
    }
}
