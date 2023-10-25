using AutoMapper;
using Jca.Sigmuni.Domain.Zonificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros.Maps
{
    public class LoteZonificacionParametroProfileAction : IMappingAction<LoteZonificacionParametro, LoteZonificacionParametroDto>
    {
        public void Process(LoteZonificacionParametro source, LoteZonificacionParametroDto destination,
           ResolutionContext context)
        {

            destination.Id = source.Id;

           
            //if (source.ZonificacionParametro != null)
            //{
            //    destination.ZonificacionParametro = context.Mapper.Map<ZonificacionParametroDto>(source.ZonificacionParametro);
               
            //}

         


        }
    }
}