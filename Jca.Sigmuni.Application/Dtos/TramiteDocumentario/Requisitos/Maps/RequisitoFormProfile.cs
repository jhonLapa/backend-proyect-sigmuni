using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Requisitos.Maps
{
    public class RequisitoFormProfile : Profile
    {
        public RequisitoFormProfile()
        {
            CreateMap<Requisito, RequisitoFormDto>().ReverseMap();
        }
    }
}


