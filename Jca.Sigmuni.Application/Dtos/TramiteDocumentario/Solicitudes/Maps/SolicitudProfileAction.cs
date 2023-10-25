using AutoMapper;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Pagos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudRequisitos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes.Maps
{
    public class SolicitudProfileAction : IMappingAction<Solicitud, SolicitudDto>
    {
        public void Process(Solicitud source, SolicitudDto destination, ResolutionContext context)
        {
            if(source.Pagos !=null)
            {
                destination.Pagos = context.Mapper.Map<List<PagoDto>>(source.Pagos);
            }
            if (source.SolicitudRequisitos != null)
            {
                destination.SolicitudRequisitos = context.Mapper.Map<List<SolicitudRequisitoDto>>(source.SolicitudRequisitos);
            }
        }
    }
}
