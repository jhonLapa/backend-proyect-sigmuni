using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TramiteSolicituds.Maps
{
    public class TramiteSolicitudProfile:Profile
    {
        public TramiteSolicitudProfile() 
        {
            CreateMap<TramiteSolicitud,TramiteSolicitudDto>();
            CreateMap<TramiteSolicitud, TramiteSolicitudDto>().ReverseMap();

            CreateMap<RequestPagination<TramiteSolicitud>, RequestPagination<TramiteSolicitudDto>>().ReverseMap();
            CreateMap<ResponsePagination<TramiteSolicitud>, ResponsePagination<TramiteSolicitudDto>>();
        }
    }
}
