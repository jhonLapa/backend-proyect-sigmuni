using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos.Maps
{
    public class InfDocumentoFormProfile : Profile
    {
        public InfDocumentoFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoDto>().ReverseMap();
        }
    }
}
