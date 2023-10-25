using AutoMapper;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas.Maps
{
    internal class FichaBusquedaProfileAction : IMappingAction<FichaBusqueda, FichaBusquedaDto>
    {
        public void Process(FichaBusqueda source, FichaBusquedaDto destination, ResolutionContext context)
        {
            destination.Id= source.Id;
            destination.IdUnidadCatastral = source.IdUnidadCatastral.ToString();
            if(source.IdFichaControl!=null)
                destination.IdFichaControl= source.IdFichaControl.ToString();
        }
    }
}
