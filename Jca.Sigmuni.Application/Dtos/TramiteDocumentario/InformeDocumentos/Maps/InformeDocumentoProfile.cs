using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos.Maps;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeDocumentos.Maps
{
    public class InformeDocumentoProfile : Profile
    {
        public InformeDocumentoProfile()
        {
            CreateMap<AdjuntoInforme, InformeDocumentoDto>();
            CreateMap<AdjuntoInforme, InformeDocumentoDto>().ReverseMap();


        }
    }
}
