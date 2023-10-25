using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Autoridades;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Rangos.Maps
{
    public class RangoProfile:Profile
    {
        public RangoProfile() {
            CreateMap<Rango, RangoDto>();
            CreateMap<Rango, RangoDto>().ReverseMap();

            CreateMap<RequestPagination<Rango>, RequestPagination<RangoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Rango>, ResponsePagination<RangoDto>>();
        }
    }
}
