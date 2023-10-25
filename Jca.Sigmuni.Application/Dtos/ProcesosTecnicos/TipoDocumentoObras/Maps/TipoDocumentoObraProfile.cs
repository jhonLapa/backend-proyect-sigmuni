using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras.Maps
{
    public class TipoDocumentoObraProfile : Profile
    {
        public TipoDocumentoObraProfile()
        {
            CreateMap<TipoDocumentoObra, TipoDocumentoObraDto>();
            CreateMap<TipoDocumentoObra, TipoDocumentoObraDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDocumentoObra>, RequestPagination<TipoDocumentoObraDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDocumentoObra>, ResponsePagination<TipoDocumentoObraDto>>();
        }
    }
}
