using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios.Maps
{
    public class UbicacionPredioProfileAction : IMappingAction<UbicacionPredio, UbicacionPredioDto>
    {
        public void Process(UbicacionPredio source, UbicacionPredioDto destination, ResolutionContext context)
        {
            destination.Id = source.IdUbicacionPredio;

            if (source.HabilitacionUrbana != null)
            {
                destination.HabilitacionUrbana = context.Mapper.Map<HabilitacionUrbanaFichaDto>(source.HabilitacionUrbana);
            }
        }
    }
}
