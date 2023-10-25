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
    public class SolicitudBusquedaProfile :Profile
    {
        public SolicitudBusquedaProfile() 
        {
            CreateMap<SolicitudBusqueda,SolicitudBusquedaDto>();
            CreateMap<SolicitudBusqueda, SolicitudBusquedaDto>().ReverseMap();

            CreateMap<RequestPagination<SolicitudBusqueda>,RequestPagination<SolicitudBusquedaDto>>().ReverseMap();
            CreateMap<ResponsePagination<SolicitudBusqueda>, ResponsePagination<SolicitudBusquedaDto>>();
        }

    }
}
