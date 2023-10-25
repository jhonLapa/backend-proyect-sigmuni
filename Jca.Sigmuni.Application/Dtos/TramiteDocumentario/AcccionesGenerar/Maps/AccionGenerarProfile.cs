using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.AcccionesGenerar.Maps
{
    public class AccionGenerarProfile:Profile
    {
        public AccionGenerarProfile() {
            CreateMap<AccionGenerar, AccionGenerarDto>();
            CreateMap<AccionGenerar, AccionGenerarDto>().ReverseMap();

            CreateMap<RequestPagination<AccionGenerar>, RequestPagination<AccionGenerarDto>>().ReverseMap();
            CreateMap<ResponsePagination<AccionGenerar>, ResponsePagination<AccionGenerarDto>>();
        }   
    }
}
