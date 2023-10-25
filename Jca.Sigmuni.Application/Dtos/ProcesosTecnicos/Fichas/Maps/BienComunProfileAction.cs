using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DocumentoObras;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapBienComunComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Resoluciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class BienComunProfileAction : IMappingAction<Ficha, BienComunDto>
    {
        public void Process(Ficha source, BienComunDto destination, ResolutionContext context)
        {
            destination.Ficha = context.Mapper.Map<FichaDto>(source);

            if (source.UnidadCatastral != null)
            {
                destination.UnidadCatastral = context.Mapper.Map<UnidadCatastralDto>(source.UnidadCatastral);

                if (source.UnidadCatastral.TblCodigo != null && source.UnidadCatastral.TblCodigo.Count > 1)
                {
                    foreach (var item in source.UnidadCatastral.TblCodigo)
                    {
                        switch (item.FlagTipo)
                        {
                            case FlagTipoCodigo.CodigoCatastral:
                                destination.CodigoCatastral = context.Mapper.Map<TblCodigoCatastralDto>(item);
                                destination.CodigoCatastral.CodEdif = "X";
                                destination.CodigoCatastral.CodEnt = "X";
                                destination.CodigoCatastral.CodPiso = "X";
                                destination.CodigoCatastral.CodUnid = "X";
                                destination.CodigoCatastral.DigitoControl = "X";
                                break;
                            case FlagTipoCodigo.CodigoCatastralReferencial:
                                destination.CodigoCatastralRef = context.Mapper.Map<TblCodigoCatastralRefDto>(item);
                                destination.CodigoCatastralRef.CodEdif = "X";
                                destination.CodigoCatastralRef.CodEnt = "X";
                                destination.CodigoCatastralRef.CodPiso = "X";
                                destination.CodigoCatastralRef.CodUnid = "X";
                                destination.CodigoCatastralRef.DigitoControl = "X";
                                break;
                        }
                    }
                }

            }
            if (source.UbicacionPredios != null && source.UbicacionPredios.Count > 0)
            {
                destination.Ubicacion = context.Mapper.Map<UbicacionPredioDto>(source.UbicacionPredios.FirstOrDefault());

                destination.Edificacion = context.Mapper.Map<EdificacionDto>(source.UbicacionPredios.FirstOrDefault().Edificacion);
                destination.Puertas = context.Mapper.Map<List<PuertaDto>>(source.UbicacionPredios.FirstOrDefault().Puertas);
            }

            if (source.DescripcionPredios != null)
            {
                destination.DescripcionPredio = context.Mapper.Map<DescripcionPredioDto>(source.DescripcionPredios.FirstOrDefault());
            }
            if (source.EvaluacionPredios != null)
            {
                destination.EvaluacionPredio = context.Mapper.Map<EvaluacionPredioDto>(source.EvaluacionPredios.FirstOrDefault());
            }
            if (source.ServicioBasicos != null)
            {
                destination.ServicioBasico = context.Mapper.Map<ServicioBasicoDto>(source.ServicioBasicos.FirstOrDefault());
            }

            if (source.Construcciones != null && source.Construcciones.Count > 0)
            {
                destination.Construcciones = context.Mapper.Map<List<ConstruccionDto>>(source.Construcciones);
            }

            if (source.FichaIndividuales != null)
            {
                destination.IndividualAdicional = context.Mapper.Map<FichaIndividualDto>(source.FichaIndividuales.FirstOrDefault());
            }

            if (source.OtraInstalaciones != null && source.OtraInstalaciones.Count > 0)
            {
                destination.OtraInstalaciones = context.Mapper.Map<List<OtraInstalacionDto>>(source.OtraInstalaciones);
            }

            if (source.RecapitulacionEdificios != null && source.RecapitulacionEdificios.Count > 0)
            {
                destination.RecapEdificios = context.Mapper.Map<List<RecapitulacionEdificioDto>>(source.RecapitulacionEdificios);
            }

            if (source.RecapitulacionBienComunes != null && source.RecapitulacionBienComunes.Count > 0)
            {
                destination.RecapBienComunes = context.Mapper.Map<List<RecapitulacionBienComunDto>>(source.RecapitulacionBienComunes);
            }

            if (source.RecapBienComunComplementarios != null)
            {
                destination.RecapBienComunComplemetarios = context.Mapper.Map<List<RecapBienComunComplementarioDto>>(source.RecapBienComunComplementarios);
            }

            if (source.Sunarps != null && source.Sunarps.Count > 0)
            {
                destination.Inscripciones = context.Mapper.Map<List<SunarpDto>>(source.Sunarps);
            }

            if (source.RegistroLegales != null && source.RegistroLegales.Count > 0)
            {
                destination.InfoLegal = context.Mapper.Map<List<RegistroLegalDto>>(source.RegistroLegales);
            }


            if (source.InfoComplementarios != null)
            {
                destination.InfoComplementario = context.Mapper.Map<InfoComplementarioDto>(source.InfoComplementarios.FirstOrDefault());
            }

            if (source.Declarantes != null && source.Declarantes.Count > 0)
            {
                destination.DeclaranteInfo = context.Mapper.Map<DeclarantePersonaDto>(source.Declarantes.FirstOrDefault().Persona);

                if (destination.DeclaranteInfo == null) destination.DeclaranteInfo = new DeclarantePersonaDto();

                destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(source.Declarantes.FirstOrDefault().CondicionPer);
                destination.DeclaranteInfo.IdDeclarante = source.Declarantes.FirstOrDefault().IdDeclarante;
                destination.DeclaranteInfo.Fecha = source.Declarantes.FirstOrDefault().Fecha;
                destination.DeclaranteInfo.TieneFirma = source.Declarantes.FirstOrDefault().TieneFirma;
            }

            if (source.Supervisores != null && source.Supervisores.Count > 0)
            {
                destination.SupervisorInfo = context.Mapper.Map<SupervisorPersonaDto>(source.Supervisores.FirstOrDefault().Persona);
                destination.SupervisorInfo.IdSupervisor = source.Supervisores.FirstOrDefault().IdSupervisor;
                destination.SupervisorInfo.Fecha = source.Supervisores.FirstOrDefault().Fecha;
                destination.SupervisorInfo.TieneFirma = source.Supervisores.FirstOrDefault().TieneFirma;
            }
            if (source.Resoluciones != null)
            {
                destination.Resoluciones = context.Mapper.Map<List<ResolucionDto>>(source.Resoluciones);
            }
            if (source.DocumentoObras != null)
            {
                destination.DocumentosObra = context.Mapper.Map<List<DocumentoObraDto>>(source.DocumentoObras);
            }
            if (source.TecnicoCatastrales != null && source.TecnicoCatastrales.Count > 0)
            {
                destination.TecnicoInfo = context.Mapper.Map<TecnicoCatastralPersonaDto>(source.TecnicoCatastrales.FirstOrDefault().Persona);
                destination.TecnicoInfo.IdTecnico = source.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;
                destination.TecnicoInfo.Fecha = source.TecnicoCatastrales.FirstOrDefault().Fecha;
                destination.TecnicoInfo.TieneFirma = source.TecnicoCatastrales.FirstOrDefault().TieneFirma;
            }
        }
    }
}
