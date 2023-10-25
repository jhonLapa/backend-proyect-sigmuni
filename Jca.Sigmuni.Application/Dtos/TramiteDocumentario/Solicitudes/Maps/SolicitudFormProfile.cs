using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes.Maps
{
    public class SolicitudFormProfile :Profile
    {
        public SolicitudFormProfile() 
        {
            
            CreateMap<Solicitud, SolicitudFormDto>();
            CreateMap<Solicitud, SolicitudFormDto>().ReverseMap();
        }
    }
}
