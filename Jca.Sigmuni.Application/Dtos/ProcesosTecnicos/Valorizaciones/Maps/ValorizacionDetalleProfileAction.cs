using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones.Maps
{
    public class ValorizacionDetalleProfileAction : IMappingAction<Ficha, ValorizacionDetalleDto>
    {
        public void Process(Ficha source, ValorizacionDetalleDto destination, ResolutionContext context)
        {
            destination.AnioFicha = source.AnioFicha;

            if(source.Construcciones.Count > 0 )
            {
                destination.ValorConstruccion = context.Mapper.Map<List<ValorConstruccionDto>>(source.Construcciones);
            }

            if (source.TitularCatastral != null && source.TitularCatastral.Count > 0)
            {
                if (source?.TitularCatastral?.FirstOrDefault()?.Persona != null)
                {
                    destination.Titular = context.Mapper.Map<PersonaTitularDto>(source?.TitularCatastral?.FirstOrDefault()?.Persona);
                }
            }

            if (source?.UbicacionPredios != null && source.UbicacionPredios.Count > 0)
            {
                destination.Ubicacion = context.Mapper.Map<UbicacionPredioDto>(source.UbicacionPredios.FirstOrDefault());
                if (source?.UbicacionPredios?.FirstOrDefault()?.Edificacion != null)
                {
                    destination.Manzana = source.UbicacionPredios.FirstOrDefault().Edificacion.Manzana;
                    destination.NumLote = source.UbicacionPredios.FirstOrDefault().Edificacion.NumLote;
                }
                if (source.UbicacionPredios.FirstOrDefault().Puertas.Count > 0)
                {
                    destination.NumeroInterior = source.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().NumeroInterior;
                    destination.NumeroMunicipal = source.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().NumeracionMunicipal;
                    if (source.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via != null)
                        destination.Via = context.Mapper.Map<ViaDto>(source.UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via);
                }
            }

            if (source.UnidadCatastral != null)
            {
                if (source.UnidadCatastral.TblCodigo != null && source.UnidadCatastral.TblCodigo.Count > 1)
                {
                    foreach (var item in source.UnidadCatastral.TblCodigo)
                    {
                        switch (item.FlagTipo)
                        {
                            case FlagTipoCodigo.CodigoCatastral:
                                destination.CodigoCatastral = context.Mapper.Map<TblCodigoCatastralDto>(item);
                                break;
                        }
                    }
                }

            }
        }
    }
}
