using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas.Maps
{
    public class TipoDocumentoFichaProfile : Profile
    {
        public TipoDocumentoFichaProfile()
        {
            CreateMap<TipoDocumentoFicha, TipoDocumentoFichaDto>();
            CreateMap<TipoDocumentoFicha, TipoDocumentoFichaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDocumentoFicha>, RequestPagination<TipoDocumentoFichaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDocumentoFicha>, ResponsePagination<TipoDocumentoFichaDto>>();
        }
    }
}
