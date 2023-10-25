using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Documentos.Maps
{
    public class DocumentoB64Profile : Profile
    {
        public DocumentoB64Profile()
        {
            CreateMap<Documento, DocumentoDto>();
            CreateMap<Documento, DocumentoDto>().ReverseMap();

            CreateMap<RequestPagination<Documento>, RequestPagination<DocumentoDto>>().ReverseMap();
            CreateMap<ResponsePagination<Documento>, ResponsePagination<DocumentoDto>>();
        }
    }
}
