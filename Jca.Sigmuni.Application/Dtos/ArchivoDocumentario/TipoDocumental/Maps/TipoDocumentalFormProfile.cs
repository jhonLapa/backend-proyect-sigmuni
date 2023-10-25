using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TipoDocumental.Maps
{
    public class TipoDocumentalFormProfile : Profile
    {
        public TipoDocumentalFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.TipoDocumental, TipoDocumentalFormDto>().ReverseMap();
        }
    }
}
