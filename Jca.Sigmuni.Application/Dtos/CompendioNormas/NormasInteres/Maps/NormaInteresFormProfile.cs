using AutoMapper;
using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres.Maps
{
    public class NormaInteresFormProfile : Profile
    {
        public NormaInteresFormProfile()
        {
            CreateMap<NormaInteres, NormaInteresFormDto>().ReverseMap();
        }
    }
}
