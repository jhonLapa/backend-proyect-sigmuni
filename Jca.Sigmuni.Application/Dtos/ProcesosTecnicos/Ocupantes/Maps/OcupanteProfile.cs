using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes.Maps
{
    public class OcupanteProfile : Profile
    {
        public OcupanteProfile()
        {
            CreateMap<Ocupante, OcupanteDto>();
            CreateMap<Ocupante, OcupanteDto>().ReverseMap();

            CreateMap<RequestPagination<Ocupante>, RequestPagination<OcupanteDto>>().ReverseMap();
            CreateMap<ResponsePagination<Ocupante>, ResponsePagination<OcupanteDto>>();
        }
    }
}
