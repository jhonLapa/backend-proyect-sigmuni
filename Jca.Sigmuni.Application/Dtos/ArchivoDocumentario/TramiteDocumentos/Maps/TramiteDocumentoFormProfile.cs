using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos.Maps
{
    public class TramiteDocumentoFormProfile : Profile
    {
        public TramiteDocumentoFormProfile()
        {
            CreateMap<Domain.TramiteDocumentario.TramiteDocumento, TramiteDocumentoFormDto>().ReverseMap();
        }
    }
}
