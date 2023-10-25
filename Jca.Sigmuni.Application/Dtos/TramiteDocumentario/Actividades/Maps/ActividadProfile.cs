using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades.Maps
{
    public class ActividadProfile :Profile
    {
        public ActividadProfile() 
        {
            CreateMap<Actividad, ActividadDto>();
            CreateMap<Actividad,ActividadDto>().ReverseMap();

            CreateMap<RequestPagination<Actividad>, RequestPagination<ActividadDto>>().ReverseMap();
            CreateMap<ResponsePagination<Actividad>, ResponsePagination<ActividadDto>>();
        }
    }
}
