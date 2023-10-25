using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SerieDocumental.Maps
{
    public class SerieDocumentalFormProfile : Profile
    {
        public SerieDocumentalFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.SerieDocumental, SerieDocumentalFormDto>().ReverseMap();
        }
    }
}
