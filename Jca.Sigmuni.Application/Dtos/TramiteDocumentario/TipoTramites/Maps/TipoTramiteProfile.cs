using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoTramites.Maps
{
    public class TipoTramiteProfile:Profile
    {
        public TipoTramiteProfile() {
            CreateMap<TipoTramite, TipoTramiteDto>();
            CreateMap<TipoTramite, TipoTramiteDto>().ReverseMap();

            CreateMap<RequestPagination<TipoTramite>, RequestPagination<TipoTramiteDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoTramite>, ResponsePagination<TipoTramiteDto>>();
        }
    }
}
