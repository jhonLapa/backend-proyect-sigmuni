using AutoMapper;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaDerogadaProfile :Profile
    {
        public NormaDerogadaProfile() 
        {
            CreateMap<NormaDerogada,NormaDerogadaDto>();
            CreateMap<NormaDerogada, NormaDerogadaDto>().ReverseMap();
        }
    }
}
