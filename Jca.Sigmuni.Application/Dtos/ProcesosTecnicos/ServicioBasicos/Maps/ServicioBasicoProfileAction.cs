using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoServiciosBasicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos.Maps
{
    internal class ServicioBasicoProfileAction : IMappingAction<ServicioBasico, ServicioBasicoDto>
    {
        public void Process(ServicioBasico source, ServicioBasicoDto destination, ResolutionContext context)
        {
            destination.IdServicioBasico = source.IdServicioBasico;

            if (source.TipoServicioBasicoLuz != null)
            {
                destination.Luz = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoLuz);
            }
            if (source.TipoServicioBasicoAgua != null)
            {
                destination.Agua = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoAgua);
            }
            if (source.TipoServicioBasicoTelefono != null)
            {
                destination.Telefono = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoTelefono);
            }
            if (source.TipoServicioBasicoDesague != null)
            {
                destination.Desague = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoDesague);
            }
            if (source.TipoServicioBasicoGas != null)
            {
                destination.Gas = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoGas);
            }
            if (source.TipoServicioBasicoInternet != null)
            {
                destination.Internet = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoInternet);
            }

            if (source.TipoServicioBasicoCable != null)
            {
                destination.Cable = context.Mapper.Map<TipoServicioBasicoDto>(source.TipoServicioBasicoCable);
            }
        }
    }
}
