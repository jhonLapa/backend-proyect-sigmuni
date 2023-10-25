using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores.Map
{
    public class DomicilioConductorProfileAction : IMappingAction<Domicilio, DomicilioConductorDto>
    {
        public void Process(Domicilio source, DomicilioConductorDto destination, ResolutionContext context)
        {
            destination.NumeroInterior = source.NumInterior;
            if(source.HabilitacionUrbana != null)
            {
                destination.HabilitacionesUrbanas = context.Mapper.Map<HabilitacionUrbanaFichaDto>(source.HabilitacionUrbana);
            }
        }
    }
}
