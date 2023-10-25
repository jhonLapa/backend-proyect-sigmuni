using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs.Maps
{
    public class SolicitudCucProfile : Profile
    {
        public SolicitudCucProfile()
        {
            CreateMap<SolicitudCuc, SolicitudCucDto>();
            CreateMap<SolicitudCuc, SolicitudCucDto>().ReverseMap();

            CreateMap<RequestPagination<SolicitudCuc>, RequestPagination<SolicitudCucDto>>().ReverseMap();
            CreateMap<ResponsePagination<SolicitudCuc>, ResponsePagination<SolicitudCucDto>>();
        }
    }
}
