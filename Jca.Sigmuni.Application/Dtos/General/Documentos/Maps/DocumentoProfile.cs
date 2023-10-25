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
    public class DocumentoProfile: Profile
    {
        public DocumentoProfile()
        {
            CreateMap<DocumentoB64, DocumentoB64Dto>();
            CreateMap<DocumentoB64, DocumentoB64Dto>().ReverseMap();

            CreateMap<RequestPagination<DocumentoB64>, RequestPagination<DocumentoB64Dto>>().ReverseMap();
            CreateMap<ResponsePagination<DocumentoB64>, ResponsePagination<DocumentoB64Dto>>();
        }
    }
}
