using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos.Maps
{
    public class DatosSolicitudProfile : Profile
    {
        public DatosSolicitudProfile()
        {
            //CreateMap<Solicitud, DatosSolicitudDto>();
            //CreateMap<Solicitud, DatosSolicitudDto>().ReverseMap();

            CreateMap<Solicitud, DatosSolicitudDto>()
             .AfterMap<DatosSolicitudProfileAction>();
        }
    }
}
