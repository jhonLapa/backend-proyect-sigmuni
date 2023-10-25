using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.LinderoPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios.Maps
{
    public class DescripcionPredioProfileAction : IMappingAction<DescripcionPredio, DescripcionPredioDto>
    {
        public void Process(DescripcionPredio source, DescripcionPredioDto destination, ResolutionContext context)
        {
            destination.IdDescripcionPredio = source.IdDescripcionPredio;

            if (source.ClasificacionPredio != null)
            {
                destination.ClasificacionPredio = context.Mapper.Map<ClasificacionPredioDto>(source.ClasificacionPredio);
            }

            if (source.UsoPredio != null)
            {
                destination.UsoPredio = context.Mapper.Map<UsoPredioDto>(source.UsoPredio);
            }

            if (source.PredioCatastralEn != null)
            {
                destination.PredioCatastralEn = context.Mapper.Map<PredioCatastralEnDto>(source.PredioCatastralEn);
            }

            if (source.LinderoPredio != null)
            {
                destination.LinderoPredio = context.Mapper.Map<LinderoPredioDto>(source.LinderoPredio);
            }
        }
    }
}
