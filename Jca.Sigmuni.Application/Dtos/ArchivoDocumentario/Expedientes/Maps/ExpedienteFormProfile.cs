using AutoMapper;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Expedientes.Maps
{
    public class ExpedienteFormProfile : Profile
    {
        public ExpedienteFormProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.Expediente, ExpedienteFormDto>().ReverseMap();
        }
    }
}
