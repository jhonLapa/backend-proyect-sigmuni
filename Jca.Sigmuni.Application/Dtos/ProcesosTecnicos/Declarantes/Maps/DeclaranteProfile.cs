using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes.Maps
{
    public class DeclaranteProfile : Profile
    {
        public DeclaranteProfile()
        {
            CreateMap<Declarante, DeclaranteDto>();
            CreateMap<Declarante, DeclaranteDto>().ReverseMap();

            CreateMap<RequestPagination<Declarante>, RequestPagination<DeclaranteDto>>().ReverseMap();
            CreateMap<ResponsePagination<Declarante>, ResponsePagination<DeclaranteDto>>();
        }
    }
}
