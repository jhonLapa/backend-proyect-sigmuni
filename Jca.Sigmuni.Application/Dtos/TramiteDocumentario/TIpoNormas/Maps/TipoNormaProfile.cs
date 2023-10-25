using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TIpoNormas.Maps
{
    public class TipoNormaProfile:Profile
    {
        public TipoNormaProfile() 
        {
            CreateMap<TipoNorma, TipoNormaDto>();
            CreateMap<TipoNorma,TipoNormaDto>().ReverseMap();

            CreateMap<RequestPagination<TipoNorma>,RequestPagination<TipoNormaDto>>().ReverseMap();
            CreateMap<ResponsePagination<TipoNorma>, ResponsePagination<TipoNormaDto>>();
        }
    }
}
