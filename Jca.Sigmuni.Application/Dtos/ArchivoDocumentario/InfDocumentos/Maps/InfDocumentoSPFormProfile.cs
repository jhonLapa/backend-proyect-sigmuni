using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos.Maps
{
    public class InfDocumentoSPFormProfile : Profile
    {
        public InfDocumentoSPFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoSPFormDto>().ReverseMap();
        }
    }
}
