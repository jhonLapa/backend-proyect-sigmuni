using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Motivos;
using Jca.Sigmuni.Application.Dtos.General.Observaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EstadosLlenados;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios.Maps
{
    public class InfoComplemetarioProfileAction : IMappingAction<InfoComplementario, InfoComplementarioDto>
    {
        public void Process(InfoComplementario source, InfoComplementarioDto destination, ResolutionContext context)
        {
            destination.IdInfoComplementario = source.IdInfoComplementario;

            if (source.Observacion != null)
            {
                destination.Observacion = context.Mapper.Map<ObservacionDto>(source.Observacion);
            }

            if (source.TipoMantenimiento != null)
            {
                destination.TipoMantenimiento = context.Mapper.Map<TipoMantenimientoDto>(source.TipoMantenimiento);
            }

            if (source.EstadoLLenado != null)
            {
                destination.EstadoLLenado = context.Mapper.Map<EstadoLlenadoDto>(source.EstadoLLenado);
            }

            if (source.TipoInspeccion != null)
            {
                destination.TipoInspeccion = context.Mapper.Map<TipoInspeccionDto>(source.TipoInspeccion);
            }

            //if (source.Motivo != null)
            //{
            //    destination.Motivo = context.Mapper.Map<MotivoDto>(source.Motivo);
            //}
            //if (source.TipoDocumentoPresentado != null)
            //{
            //    destination.TipoDocPresentado = context.Mapper.Map<TipoDocumentoFichaDto>(source.TipoDocumentoPresentado);
            //}
        }
    }
}
