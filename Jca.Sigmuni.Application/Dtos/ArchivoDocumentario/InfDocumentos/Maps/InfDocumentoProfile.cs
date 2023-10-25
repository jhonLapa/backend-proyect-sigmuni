using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.InfDocumentos.Maps
{
    public class InfDocumentoProfile : Profile
    {
        public InfDocumentoProfile()
        {
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoDto>();
            CreateMap<Domain.ArchivoDocumentario.InfDocumento, InfDocumentoDto>().ReverseMap();

            CreateMap<RequestPagination<Domain.ArchivoDocumentario.InfDocumento>, RequestPagination<InfDocumentoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Domain.ArchivoDocumentario.InfDocumento>, ResponsePagination<InfDocumentoDto>>();
        }
    }
}
