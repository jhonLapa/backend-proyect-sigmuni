using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    public class PersonaSolicitudFormProfile:Profile
    {
        public PersonaSolicitudFormProfile() 
        {
            CreateMap<Persona, PersonaSolicitudFormDto>();
            CreateMap<Persona, PersonaSolicitudFormDto>().ReverseMap();
        }
    }
}
