using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas.Maps
{
    public class FichaBusquedaProfileActionReverse : IMappingAction<FichaBusquedaDto, FichaBusqueda>
    {
        public void Process(FichaBusquedaDto source, FichaBusqueda destination, ResolutionContext context)
        {
            destination.IdFichaControl = (long)Convert.ToDouble(source.IdFichaControl);
            destination.IdUnidadCatastral = (long)Convert.ToDouble(source.IdUnidadCatastral);

        }
    }
}
