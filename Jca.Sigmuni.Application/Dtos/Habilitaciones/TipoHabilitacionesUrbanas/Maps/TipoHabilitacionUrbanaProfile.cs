using AutoMapper;
using Jca.Sigmuni.Domain.Habilitaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas.Maps
{
    public class TipoHabilitacionUrbanaProfile : Profile
    {
        public TipoHabilitacionUrbanaProfile()
        {
            CreateMap<TipoHabilitacionUrbana, TipoHabilitacionUrbanaDto>();
        }
    }
}
