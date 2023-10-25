using AutoMapper;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades.Maps
{
    public class ActividadFormProfile:Profile
    {
        public ActividadFormProfile() 
        { 
            CreateMap<Actividad,ActividadFormDto>().ReverseMap();
        }
    }
}
