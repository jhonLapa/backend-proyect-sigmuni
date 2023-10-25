using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades.Maps
{
    public class DocumentoIdentidadFormProfile : Profile
    {
        public DocumentoIdentidadFormProfile()
        {
            CreateMap<DocumentoIdentidad, DocumentoIdentidadFormDto>().ReverseMap();
        }
    }
}


