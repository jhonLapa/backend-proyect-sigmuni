using AutoMapper;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas.Maps
{
    public class PuertaProfileAction : IMappingAction<Puerta, PuertaDto>
    {
        public void Process(Puerta source, PuertaDto destination, ResolutionContext context)
        {
            if (source.TipoPuerta != null)
            {
                destination.TipoPuerta = context.Mapper.Map<TipoPuertaDto>(source.TipoPuerta);
            }
            if (source.TipoInterior != null)
            {
                destination.TipoInterior = context.Mapper.Map<TipoInteriorDto>(source.TipoInterior);
            }
            //if (source.UbicacionNumeracion != null)
            //{
            //    destination.UbicacionNumeracion = context.Mapper.Map<UbicacionNumeracionDto>(source.UbicacionNumeracion);
            //}
            if (source.CondicionNumeracion != null)
            {
                //var condNumPrincipal = _condicionNumeracionRepositorio.BuscarPorIdAsync(source.IdCondNumPrincipal.Value);
                destination.CondicionNumeracion = context.Mapper.Map<CondicionNumeracionDto>(source.CondicionNumeracion);
            }
            //if (source.CondicionNumeracion2 != null)
            //{
            //    //var condNumSecundario = _condicionNumeracionRepositorio.BuscarPorIdAsync(source.IdCondNumSecundario.Value);
            //    destination.CondNumSecundario = context.Mapper.Map<CondicionNumeracionDto>(source.CondicionNumeracion2);
            //}

            //if (source.TipoNumeracion != null)
            //{
            //    //var tipoNumPrincipal = _tipoNumeracionRepositorio.BuscarPorIdAsync(source.IdTipoNumPrincipal.Value);
            //    destination.TipoNumPrincipal = context.Mapper.Map<TipoNumeracionDto>(source.TipoNumeracion);
            //}

            //if (source.TipoNumeracion2 != null)
            //{
            //    //var tipoNumSecundario = _tipoNumeracionRepositorio.BuscarPorIdAsync(source.IdTipoNumSecundario.Value);
            //    destination.TipoNumSecundario = context.Mapper.Map<TipoNumeracionDto>(source.TipoNumeracion2);
            //}

            if (source.Via != null)
            {
                destination.Via = context.Mapper.Map<ViaDto>(source.Via);
            }
        }
    }
}
