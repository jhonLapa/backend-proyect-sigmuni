using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Application.Dtos.General.EstadosAcabados.Maps
{
    public class EstadoAcabadoProfile : Profile
    {
        public EstadoAcabadoProfile()
        {
            CreateMap<EstadoAcabado, EstadoAcabadoDto>();
            CreateMap<EstadoAcabado, EstadoAcabadoDto>().ReverseMap();

            CreateMap<RequestPagination<EstadoAcabado>, RequestPagination<EstadoAcabadoDto>>().ReverseMap();
            CreateMap<ResponsePagination<EstadoAcabado>, ResponsePagination<EstadoAcabadoDto>>();
        }
    }
}
