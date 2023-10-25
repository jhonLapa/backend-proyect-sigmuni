using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Documentos.Maps
{
    public class DocumentoFormProfile : Profile
    {
        public DocumentoFormProfile()
        {
            CreateMap<Documento, DocumentoB64FormDto>().ReverseMap();
        }
    }
}
