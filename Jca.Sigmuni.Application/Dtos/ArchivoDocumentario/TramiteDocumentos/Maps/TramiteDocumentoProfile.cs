using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.Marcadores;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos.Maps
{
    public class TramiteDocumentoProfile : Profile
    {
        public TramiteDocumentoProfile()
        {
            CreateMap<Domain.TramiteDocumentario.TramiteDocumento, TramiteDocumentoDto>();
            CreateMap<Domain.TramiteDocumentario.TramiteDocumento, TramiteDocumentoDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.TramiteDocumentario.TramiteDocumento>, RequestPagination<TramiteDocumentoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.TramiteDocumentario.TramiteDocumento>, ResponsePagination<TramiteDocumentoDto>>();
        }
    }
}
