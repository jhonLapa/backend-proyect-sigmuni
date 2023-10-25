using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PredioCatastralesAn;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales.Maps
{
    public class FichaIndividualProfileAction : IMappingAction<FichaIndividual, FichaIndividualDto>
    {
        public void Process(FichaIndividual source, FichaIndividualDto destination, ResolutionContext context)
        {
            if (source.TipoDeclaratoria != null)
            {
                destination.TipoDeclaratoria = context.Mapper.Map<TipoDeclaratoriaDto>(source.TipoDeclaratoria);
            }

            if (source.PredioCatastralAn != null)
            {
                destination.PredioCatastralAn = context.Mapper.Map<PredioCatastralAnDto>(source.PredioCatastralAn);
            }
        }
    }
}
