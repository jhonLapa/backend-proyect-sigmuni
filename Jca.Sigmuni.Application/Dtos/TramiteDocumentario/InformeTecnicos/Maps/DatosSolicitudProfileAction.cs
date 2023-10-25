using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Personas;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos.Maps
{
    public class DatosSolicitudProfileAction : IMappingAction<Solicitud, DatosSolicitudDto>
    {
        public void Process(Solicitud source, DatosSolicitudDto destination, ResolutionContext context)
        {
            destination.Id = source.Id;

            if (source.InformeTecnico != null && source.InformeTecnico.Count > 0)
            {
                foreach (var item in source.InformeTecnico)
                {
                    switch (item.IdTipoInforme)
                    {
                        case 25:
                            //destination.JsonStringInformeTecnico = item.JsonDatosSolicitud;
                            destination.NumCorrelativoInformeTec = item.NumCorrelativo;
                            break;
                        case 26:
                            //destination.JsonStringInformeObs = item.JsonDatosSolicitud;
                            destination.NumCorrelativoInformeObs = item.NumCorrelativo;
                            break;
                        case 27:
                            //destination.JsonStringInformeImpro = item.JsonDatosSolicitud;
                            destination.NumCorrelativoInformeImpro = item.NumCorrelativo;
                            break;
                        case 28:
                            //destination.JsonStringInformeAbandono = item.JsonDatosSolicitud;
                            destination.NumCorrelativoInformeAbandono = item.NumCorrelativo;
                            break;
                        case 29:
                            //destination.JsonStringInformeOtros = item.JsonDatosSolicitud;
                            destination.NumCorrelativoInformeOtros = item.NumCorrelativo;
                            break;
                    }
                }
            }

            if (source.Procedimiento != null)
            {
                destination.Procedimiento = context.Mapper.Map<ProcedimientoDto>(source.Procedimiento);
            }
            if (source.Solicitante != null)
            {
                destination.Solicitante = context.Mapper.Map<PersonaDto>(source.Solicitante);
            }
            if (source.RepresentanteLegal != null)
            {
                destination.RepresentanteLegal = context.Mapper.Map<PersonaDto>(source.RepresentanteLegal);
            }
            if (source.Pagos.Count > 0)
            {
                destination.Monto = source.Pagos.FirstOrDefault().Importe;
                destination.NumeroRecibo = source.Pagos.FirstOrDefault().NumeroRecibo;
                destination.FechaReciboReg = source.Pagos.FirstOrDefault().Fecha;
            }

            var tipoVia = "";
            var nombreVia = "";
            var numeroExterior = "";
            var numeroInterior = "";
            var ubigeo = "";
            if (source.SolicitudCuc.Count > 0)
            {
                destination.SolicitudCuc = context.Mapper.Map<List<SolicitudCucDto>>(source.SolicitudCuc);
                if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral != null)
                {
                    if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.TblCodigo != null
                        && source.SolicitudCuc.FirstOrDefault().UnidadCatastral.TblCodigo.Count > 0)
                    {
                        foreach (var item in source.SolicitudCuc.FirstOrDefault().UnidadCatastral.TblCodigo)
                        {
                            switch (item.FlagTipo)
                            {
                                case FlagTipoCodigo.CodigoCatastral:
                                    destination.CodigoCatastral = context.Mapper.Map<TblCodigoCatastralDto>(item);
                                    break;
                            }
                        }
                    }
                    if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote != null)
                    {
                        if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Manzana != null)
                        {
                            if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Manzana.Sector != null)
                            {
                                if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Manzana.Sector.Ubigeo != null)
                                {
                                    if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Manzana.Sector.Ubigeo.Nombre == "Lima")
                                    {
                                        ubigeo = "Cercado de Lima";
                                    }
                                    else
                                    {
                                        ubigeo = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Manzana.Sector.Ubigeo.Nombre;
                                    }
                                }
                            }
                        }
                        destination.IdLoteCarto = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Lote.Id;
                    }
                    if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.Count > 0)
                    {
                        if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.Count > 0)
                        {
                            if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Edificacion != null)
                            {
                                destination.LoteUrbano = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Edificacion.LoteUrbano;
                                destination.ManzanaUrbana = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Edificacion.Manzana;

                            }

                            if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.Count > 0)
                            {
                                numeroExterior = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().NumeracionMunicipal;
                                if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().NumeroInterior != null)
                                {
                                    numeroInterior = "- int. " + source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().NumeroInterior;
                                }


                                if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via != null)
                                {
                                    nombreVia = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via.Nombre;

                                    if (source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via.TipoVia != null)
                                    {
                                        tipoVia = source.SolicitudCuc.FirstOrDefault().UnidadCatastral.Fichas.FirstOrDefault().UbicacionPredios.FirstOrDefault().Puertas.FirstOrDefault().Via.TipoVia.Descripcion;
                                    }
                                }
                            }
                        }

                        if (source.SolicitudCuc.FirstOrDefault().Numero != null)
                        {
                            destination.PartidaRegistral = source.SolicitudCuc.FirstOrDefault().Numero;
                        }
                    }
                }

            }
            destination.TipoVia = tipoVia;
            destination.NombreVia = nombreVia;
            destination.NumeroExterior = numeroExterior;
            destination.NumeroInterior = numeroInterior;
            destination.Ubigeo = ubigeo;
        }
    }
}
