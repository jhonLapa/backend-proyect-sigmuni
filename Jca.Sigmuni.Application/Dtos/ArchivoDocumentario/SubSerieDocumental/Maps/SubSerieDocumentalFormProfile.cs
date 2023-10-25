using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.SubSerieDocumental.Maps
{
    public class SubSerieDocumentalFormProfile : Profile
    {
        public SubSerieDocumentalFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.SubSerieDocumental, SubSerieDocumentalFormDto>().ReverseMap();
        }
    }
}
