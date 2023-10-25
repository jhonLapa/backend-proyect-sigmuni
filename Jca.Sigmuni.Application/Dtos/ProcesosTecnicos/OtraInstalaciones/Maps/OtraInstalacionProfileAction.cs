using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones.Maps
{
    public class OtraInstalacionProfileAction : IMappingAction<OtraInstalacion, OtraInstalacionDto>
    {
        public void Process(OtraInstalacion source, OtraInstalacionDto destination, ResolutionContext context)
        {
            if (source.Uca != null)
            {
                destination.Uca = context.Mapper.Map<UcaDto>(source.Uca);
            }

            if (source.TipoOtraInstalacion != null)
            {
                destination.TipoOtraInstalacion = context.Mapper.Map<TipoOtraInstalacionDto>(source.TipoOtraInstalacion);
            }

            if (source.Ecc != null)
            {
                destination.Ecc = context.Mapper.Map<EccDto>(source.Ecc);
            }

            if (source.Ecs != null)
            {
                destination.Ecs = context.Mapper.Map<EcsDto>(source.Ecs);
            }

            if (source.Mep != null)
            {
                destination.Mep = context.Mapper.Map<MepDto>(source.Mep);
            }
            
            if (source.UnidadMedida != null)
            {
                destination.UnidadMedida = context.Mapper.Map<UnidadMedidaDto>(source.UnidadMedida);
            }
        }
    }
}
