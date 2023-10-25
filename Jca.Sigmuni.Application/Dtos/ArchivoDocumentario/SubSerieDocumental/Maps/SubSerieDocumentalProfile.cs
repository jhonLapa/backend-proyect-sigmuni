using AutoMapper;
using Jca.Sigmuni.Core.Paginations;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental.Maps
{
    public class SubSerieDocumentalProfile : Profile
    {
        public SubSerieDocumentalProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.SubSerieDocumental, SubSerieDocumentalDto>();
            CreateMap<Domain.ArchivoDocumentario.SubSerieDocumental, SubSerieDocumentalDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.SubSerieDocumental>, RequestPagination<SubSerieDocumentalDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.SubSerieDocumental>, ResponsePagination<SubSerieDocumentalDto>>();
        }
    }
}
