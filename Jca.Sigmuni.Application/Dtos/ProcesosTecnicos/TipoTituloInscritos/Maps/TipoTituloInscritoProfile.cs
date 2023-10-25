using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoTituloInscritos.Maps
{
    public class TipoTituloInscritoProfile : Profile
    {
        public TipoTituloInscritoProfile()
        {
            CreateMap<TipoTituloInscrito, TipoTituloInscritoDto>();
            CreateMap<TipoTituloInscrito, TipoTituloInscritoDto>().ReverseMap();

            CreateMap<RequestPagination<TipoTituloInscrito>, RequestPagination<TipoTituloInscritoDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoTituloInscrito>, ResponsePagination<TipoTituloInscritoDto>>();
        }
    }
}
