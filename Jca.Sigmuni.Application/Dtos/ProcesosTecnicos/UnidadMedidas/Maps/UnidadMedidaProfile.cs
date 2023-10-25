using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas.Maps
{
    public class UnidadMedidaProfile : Profile
    {
        public UnidadMedidaProfile()
        {
            CreateMap<UnidadMedida, UnidadMedidaDto>();
            CreateMap<UnidadMedida, UnidadMedidaDto>().ReverseMap();

            CreateMap<RequestPagination<UnidadMedida>, RequestPagination<UnidadMedidaDto>>().ReverseMap();
            CreateMap<ResponsePagination<UnidadMedida>, ResponsePagination<UnidadMedidaDto>>();
        }
    }
}
