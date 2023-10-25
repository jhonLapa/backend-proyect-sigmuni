using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Actividades;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos.Maps
{
    public class ProcedimientoProfileAction : IMappingAction<Procedimiento, ProcedimientoDto>
    {
        public void Process(Procedimiento source, ProcedimientoDto destination, ResolutionContext context)
        {
            if(source.Actividad?.Count >0 && source.Actividad!=null)
            {
                   
                destination.Actividad=context.Mapper.Map<List<ActividadDto>> (source.Actividad);
                
            }
        }
    }
}
