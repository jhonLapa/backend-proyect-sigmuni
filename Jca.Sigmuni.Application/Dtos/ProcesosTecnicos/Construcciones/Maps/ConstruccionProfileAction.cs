using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones.Maps
{
    public class ConstruccionProfileAction : IMappingAction<Construccion, ConstruccionDto>
    {
        public void Process(Construccion source, ConstruccionDto destination, ResolutionContext context)
        {
            destination.Id = source.IdConstruccion;

            if (source.Mep != null)
            {
                destination.Mep = context.Mapper.Map<MepDto>(source.Mep);
            }

            if (source.Ecs != null)
            {
                destination.Ecs = context.Mapper.Map<EcsDto>(source.Ecs);
            }

            if (source.Ecc != null)
            {
                destination.Ecc = context.Mapper.Map<EccDto>(source.Ecc);
            }

            if (source.Uca != null)
            {
                destination.Uca = context.Mapper.Map<UcaDto>(source.Uca);
            }

            if (source.EdificacionIndustrial != null)
            {
                destination.EdificacionIndustrial = context.Mapper.Map<EdificacionIndustrialDto>(source.EdificacionIndustrial);
            }
        }
    }
}
