using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Personas.Maps
{
    public class PersonaSolicitudProfile :Profile
    {
        public PersonaSolicitudProfile()
        {
            CreateMap<Persona, PersonaSolicitudDto>();
            CreateMap<Persona, PersonaSolicitudDto>().ReverseMap();
        }
    }
}
