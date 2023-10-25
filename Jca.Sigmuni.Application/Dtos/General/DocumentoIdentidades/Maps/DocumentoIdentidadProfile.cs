using AutoMapper;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades.Maps
{
    public class DocumentoIdentidadProfile : Profile
    {
        public DocumentoIdentidadProfile()
        {
            CreateMap<DocumentoIdentidad, DocumentoIdentidadDto>();
            CreateMap<DocumentoIdentidad, DocumentoIdentidadDto>().ReverseMap();

            CreateMap<RequestPagination<DocumentoIdentidad>, RequestPagination<DocumentoIdentidadDto>>().ReverseMap();
            CreateMap<ResponsePagination<DocumentoIdentidad>, ResponsePagination<DocumentoIdentidadDto>>();
        }
    }
}

