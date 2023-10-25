using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental.Maps
{
    public class TipoDocumentalProfile : Profile
    {
        public TipoDocumentalProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.TipoDocumental, TipoDocumentalDto>();
            CreateMap<Domain.ArchivoDocumentario.TipoDocumental, TipoDocumentalDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.TipoDocumental>, RequestPagination<TipoDocumentalDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.TipoDocumental>, ResponsePagination<TipoDocumentalDto>>();
        }
    }
}
