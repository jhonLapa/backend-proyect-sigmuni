using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos.Maps
{
    public class InformeTecnicoRespuestaProfile : Profile
    {
        public InformeTecnicoRespuestaProfile()
        {
            CreateMap<InformeTecnico, InformeTecnicoRespuestaDto>();
            CreateMap<InformeTecnico, InformeTecnicoRespuestaDto>().ReverseMap();


        }
    }
}
