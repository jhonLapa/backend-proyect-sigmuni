using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados.Maps
{
    public class EstadoLlenadoProfile : Profile
    {
        public EstadoLlenadoProfile()
        {
            CreateMap<EstadoLlenado, EstadoLlenadoDto>();
            CreateMap<EstadoLlenado, EstadoLlenadoDto>().ReverseMap();

            CreateMap<RequestPagination<EstadoLlenado>, RequestPagination<EstadoLlenadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<EstadoLlenado>, ResponsePagination<EstadoLlenadoDto>>();
        }
    }
}
