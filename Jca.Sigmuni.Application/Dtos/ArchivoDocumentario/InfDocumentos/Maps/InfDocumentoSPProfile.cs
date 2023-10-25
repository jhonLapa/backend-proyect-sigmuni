using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos.Maps
{
    public class InfDocumentoSPProfile: Profile
    {
        public InfDocumentoSPProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoSPDto>();
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoSPDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.InfDocumento>, RequestPagination<InfDocumentoSPDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.InfDocumento>, ResponsePagination<InfDocumentoSPDto>>();
        }
    }
}
