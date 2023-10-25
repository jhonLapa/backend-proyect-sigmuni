using AutoMapper;
using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales.Maps
{
    public class RepresentanteLegalFormProfile : Profile
    {
        public RepresentanteLegalFormProfile() 
        {
            CreateMap<RepresentanteLegal, RepresentanteLegalFormDto>().ReverseMap();
        }
    }
}
