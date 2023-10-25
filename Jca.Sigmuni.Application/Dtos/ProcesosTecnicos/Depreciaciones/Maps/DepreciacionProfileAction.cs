using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Domain.ProcesosTecnicos;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones.Maps
{
    public class DepreciacionProfileAction : IMappingAction<Depreciacion, DepreciacionDto>
    {


        public void Process(Depreciacion source, DepreciacionDto destination, ResolutionContext context)
        {

            if (source.Antiguedad != null)
            {
                
                destination.Antiguedad = context.Mapper.Map<AntiguedadDto>(source.Antiguedad);
            }

            if (source.Ecs != null)
            {
               
                destination.Ecs = context.Mapper.Map<EcsDto>(source.Ecs);
            }

            if (source.Mep != null)
            {
               
                destination.Mep = context.Mapper.Map<MepDto>(source.Mep);
            }

            if (source.ClasificacionPredio != null)
            {
              
                destination.ClasificacionPredio = context.Mapper.Map<ClasificacionPredioDto>(source.ClasificacionPredio);
            }

        }
    }
}
