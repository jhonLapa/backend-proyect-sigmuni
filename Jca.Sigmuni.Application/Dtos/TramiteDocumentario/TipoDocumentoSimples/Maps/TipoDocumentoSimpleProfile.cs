using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoSimples.Maps
{
    public class TipoDocumentoSimpleProfile : Profile
    {
        public TipoDocumentoSimpleProfile()
        {
            CreateMap<TipoDocumentoSimple, TipoDocumentoSimpleDto>();
            CreateMap<TipoDocumentoSimple, TipoDocumentoSimpleDto>().ReverseMap();

            CreateMap<RequestPagination<TipoDocumentoSimple>, RequestPagination<TipoDocumentoSimpleDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoDocumentoSimple>, ResponsePagination<TipoDocumentoSimpleDto>>();
        }
    }
}