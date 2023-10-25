using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales.Maps
{
    public class PersonaTitularProfile : Profile
    {
        public PersonaTitularProfile()
        {
            CreateMap<Persona, PersonaTitularDto>()
                .AfterMap<PersonaTitularProfileAction>();
        }
    }
}
