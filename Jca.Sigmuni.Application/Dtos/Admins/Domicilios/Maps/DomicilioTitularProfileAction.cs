using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios.Maps
{
    public class DomicilioTitularProfileAction : IMappingAction<Domicilio, DomicilioTitularCatastralDto>
    {
        public void Process(Domicilio source, DomicilioTitularCatastralDto destination, ResolutionContext context)
        {
            destination.NumeroInterior = source.NumInterior;
            if (source.HabilitacionUrbana != null)
            {
                destination.HabilitacionesUrbanas = context.Mapper.Map<HabilitacionUrbanaFichaDto>(source.HabilitacionUrbana);
            }
        }
    }
}
