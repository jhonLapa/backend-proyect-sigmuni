using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoOtrasInstalaciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorObraComplementarias.Maps
{
    public class ValorObraComplementariaProfileAction : IMappingAction<ValorObraComplementaria, ValorObraComplementariaDto>
    {
        public void Process(ValorObraComplementaria source, ValorObraComplementariaDto destination, ResolutionContext context)
        {
            if (source.TipoOtraInstalacion != null)
            {
                destination.TipoOtraInstalacion = context.Mapper.Map<TipoOtraInstalacionDto>(source.TipoOtraInstalacion);
            }
        }
    }
}
