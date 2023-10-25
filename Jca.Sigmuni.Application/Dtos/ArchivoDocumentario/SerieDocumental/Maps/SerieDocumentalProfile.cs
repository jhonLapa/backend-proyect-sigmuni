using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental.Maps
{
    public class SerieDocumentalProfile : Profile
    {
        public SerieDocumentalProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.SerieDocumental, SerieDocumentalDto>();
            CreateMap<Domain.ArchivoDocumentario.SerieDocumental, SerieDocumentalDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.SerieDocumental>, RequestPagination<SerieDocumentalDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.SerieDocumental>, ResponsePagination<SerieDocumentalDto>>();
        }
    }
}
