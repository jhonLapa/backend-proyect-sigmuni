using AutoMapper;
using Jca.Sigmuni.Domain.Habilitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas.Maps
{
    public class HabilitacionUrbanaFichaProfile : Profile
    {
        public HabilitacionUrbanaFichaProfile()
        {
            CreateMap<HabilitacionUrbana, HabilitacionUrbanaFichaDto>();
        }
    }
}
