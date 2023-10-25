using System;
using System.Collections.Generic;
using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ArchivoDocumentario.TramiteDocumentos.Maps
{
    public class TramiteDocumentoPFormProfile: Profile
    {
        public TramiteDocumentoPFormProfile()
        {
            CreateMap<Domain.TramiteDocumentario.TramiteDocumento, TramiteDocumentoPFormDto>().ReverseMap();
        }
    }
}
