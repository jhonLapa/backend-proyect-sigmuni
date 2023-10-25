using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes.Maps
{
    public class SolicitudProfile :Profile
    {
        public SolicitudProfile() 
        {
            CreateMap<Solicitud,SolicitudDto>();
            CreateMap<Solicitud,SolicitudDto>().ReverseMap();

            CreateMap<RequestPagination<Solicitud>,RequestPagination<SolicitudDto>>().ReverseMap();
            CreateMap<ResponsePagination<Solicitud>,ResponsePagination<SolicitudDto>>();
        }
    }
}
