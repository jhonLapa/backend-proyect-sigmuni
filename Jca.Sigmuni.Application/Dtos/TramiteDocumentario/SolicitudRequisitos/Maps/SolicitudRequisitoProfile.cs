using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos.Maps
{
    public class SolicitudRequisitoProfile:Profile
    {
        public SolicitudRequisitoProfile() 
        {
            CreateMap<SolicitudRequisito,SolicitudRequisitoDto>();
            CreateMap<SolicitudRequisito, SolicitudRequisitoDto>().ReverseMap();

            CreateMap<RequestPagination<SolicitudRequisito>, RequestPagination<SolicitudRequisitoDto>>().ReverseMap();
            CreateMap<ResponsePagination<SolicitudRequisito>, ResponsePagination<SolicitudRequisitoDto>>();
        }
    }
}
