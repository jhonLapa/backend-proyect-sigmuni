using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class IndividualProfile : Profile
    {
        public IndividualProfile() 
        {
            CreateMap<Ficha, IndividualDto>()
                .AfterMap<IndividualProfileAction>();
        }  
    }
}
