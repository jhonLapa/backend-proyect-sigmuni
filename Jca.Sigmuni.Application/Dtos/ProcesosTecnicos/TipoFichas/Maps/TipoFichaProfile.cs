using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoFichas.Maps
{
    public class TipoFichaProfile : Profile
    {
        public TipoFichaProfile()
        {
            CreateMap<TipoFicha, TipoFichaDto>();
            CreateMap<TipoFicha, TipoFichaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoFicha>, RequestPagination<TipoFichaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoFicha>, ResponsePagination<TipoFichaDto>>();
        }
    }
}
