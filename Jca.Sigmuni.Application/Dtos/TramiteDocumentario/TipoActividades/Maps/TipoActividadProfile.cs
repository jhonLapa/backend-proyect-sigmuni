using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Naturalezas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoActividades.Maps
{
    public class TipoActividadProfile:Profile
    {
        public TipoActividadProfile()
        {
            CreateMap<TipoActividad, TipoActividadDto>();
            CreateMap<TipoActividad, TipoActividadDto>().ReverseMap();

            CreateMap<RequestPagination<TipoActividad>, RequestPagination<TipoActividadDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoActividad>, ResponsePagination<TipoActividadDto>>();
        }
    }
}
