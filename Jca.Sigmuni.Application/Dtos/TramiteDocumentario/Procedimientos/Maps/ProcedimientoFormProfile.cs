using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos.Maps
{
    public class ProcedimientoFormProfile:Profile
    {
        public ProcedimientoFormProfile() 
        { 
            CreateMap<Procedimiento,ProcedimientoFormDto>().ReverseMap();
        }
    }
}
