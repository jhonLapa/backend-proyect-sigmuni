using AutoMapper;
using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaTerrenoInvalids;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DocumentoObras;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredioCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EvaluacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaIndividuales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Resoluciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ServicioBasicos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas.Maps
{
    public class IndividualProfileAction : IMappingAction<Ficha, IndividualDto>
    {
        private readonly IUbigeoRepository _ubigeoRepository;

        public IndividualProfileAction(IUbigeoRepository ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        public void Process(Ficha source, IndividualDto destination, ResolutionContext context)
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
                                break;
                            case FlagTipoCodigo.CodigoCatastralReferencial:
                                destination.CodigoCatastralRef = context.Mapper.Map<TblCodigoCatastralRefDto>(item);
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
            if (source.TitularCatastral != null && source.TitularCatastral.Count > 0)
            {
                destination.CaracteristicaTitularidad = context.Mapper.Map<CaracteristicaTitularidadDto>(source.TitularCatastral.FirstOrDefault().CaracteristicaTitularidad);
                if (source.TitularCatastral.FirstOrDefault().Persona != null)
                {
                    destination.Titular = context.Mapper.Map<PersonaTitularDto>(source.TitularCatastral.FirstOrDefault().Persona);
                    destination.Titular.NumeroDni = source.TitularCatastral.FirstOrDefault().Persona.NumeroDoc;
                    destination.Titular.NumeroRuc = source.TitularCatastral.FirstOrDefault().Persona.NumeroRuc;
                    destination.Titular.IdTitularCatastral = source.TitularCatastral.FirstOrDefault().IdTitularCatastral;
                    //destination.Titular.CodigoContribuyente = source.TitularCatastral.FirstOrDefault().CodContribuyente; // consultar por qué se reasigna el codContribuyente
                    if (source.TitularCatastral.FirstOrDefault().CodContribuyente != null)
                    {
                        destination.Titular.CodigoContribuyente = source.TitularCatastral.FirstOrDefault().CodContribuyente;
                    }
                    if (source.TitularCatastral.FirstOrDefault().Dependientes != null && source.TitularCatastral.FirstOrDefault().Dependientes.Count > 0)
                    {
                        destination.Titular.Conyuge = context.Mapper.Map<ConyugeTitularDto>(source.TitularCatastral.FirstOrDefault().Dependientes.FirstOrDefault().Persona);
                        destination.Titular.Conyuge.IdConyugue = source.TitularCatastral.FirstOrDefault().Dependientes.FirstOrDefault().Id;
                        destination.Titular.Conyuge.IdPersona = source.TitularCatastral.FirstOrDefault().Dependientes.FirstOrDefault().Persona.Id;
                    }

                    if (source.TitularCatastral.FirstOrDefault().Persona.Domicilio != null)
                    {
                        destination.DomicilioTitular = context.Mapper.Map<DomicilioTitularCatastralDto>(source.TitularCatastral.FirstOrDefault().Persona.Domicilio.FirstOrDefault());

                        if (destination.DomicilioTitular != null)
                        {
                            if (destination.DomicilioTitular.Ubigeo != null)
                            {
                                var provincia = _ubigeoRepository.BuscarPorCodigoAsync(destination.DomicilioTitular.Ubigeo.CodigoPadre);

                                if (provincia.Result != null)
                                {
                                    destination.DomicilioTitular.Provincia = context.Mapper.Map<UbigeoDto>(provincia.Result);

                                    var departamento = _ubigeoRepository.BuscarPorCodigoAsync(provincia.Result.CodigoPadre);
                                    if (departamento.Result != null)
                                    {
                                        destination.DomicilioTitular.Departamento = context.Mapper.Map<UbigeoDto>(departamento.Result);
                                    }
                                }

                            }

                        }
                    }
                    var titularCatastral = source.TitularCatastral.FirstOrDefault();
                    if (titularCatastral.Persona.ExoneracionTitulares != null && titularCatastral.Persona.ExoneracionTitulares.Count > 0) { }
                    {
                        destination.ExoneracionTitular = context.Mapper.Map<ExoneracionTitularDto>(titularCatastral.Persona.ExoneracionTitulares.FirstOrDefault());
                    }
                }
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

            if (source.FichaDocumentos != null && source.FichaDocumentos.Count > 0)
            {
                destination.Documentos = context.Mapper.Map<List<FichaDocumentoDto>>(source.FichaDocumentos);
            }

            if (source.Sunarps != null && source.Sunarps.Count > 0)
            {
                destination.Inscripciones = context.Mapper.Map<List<SunarpDto>>(source.Sunarps);
            }
            if (source.Resoluciones != null)
            {
                destination.Resoluciones = context.Mapper.Map<List<ResolucionDto>>(source.Resoluciones);
            }
            if (source.DocumentoObras != null)
            {
                destination.DocumentosObra = context.Mapper.Map<List<DocumentoObraDto>>(source.DocumentoObras);
            }
            if (source.RegistroLegales != null)
            {
                destination.InfoLegal = context.Mapper.Map<List<RegistroLegalDto>>(source.RegistroLegales);
            }

            if (source.Ocupantes != null && source.Ocupantes.Count > 0)
            {
                if (source.Ocupantes.FirstOrDefault().Persona != null)
                {
                    destination.OcupantePersona = context.Mapper.Map<OcupantePersonaDto>(source.Ocupantes.FirstOrDefault().Persona);
                }
            }

            if (source.Litigantes != null)
            {
                var naturalLitigante = new List<PersonaLitiganteDto>();
                var juridicoLitigante = new List<PersonaLitiganteJuridicoDto>();
                var conyugeLitigante = new List<ConyugeLitiganteDto>();
                foreach (var item in source.Litigantes)
                {
                    if (item.Persona != null)
                    {
                        if (!string.IsNullOrWhiteSpace(item.Persona?.NumeroDoc))
                        {
                            var natural = context.Mapper.Map<PersonaLitiganteDto>(item);
                            naturalLitigante.Add(natural);

                            if (item.Dependientes != null && item.Dependientes.Count > 0)
                            {
                                foreach (var itemC in item.Dependientes)
                                {
                                    var conyugue = context.Mapper.Map<ConyugeLitiganteDto>(itemC.Persona);
                                    conyugeLitigante.Add(conyugue);
                                }
                            }
                        }

                        if (!string.IsNullOrWhiteSpace(item.Persona?.NumeroRuc))
                        {
                            var juridico = context.Mapper.Map<PersonaLitiganteJuridicoDto>(item);
                            juridicoLitigante.Add(juridico);
                        }
                    }


                }
                destination.Litigantes = naturalLitigante;
                destination.JuridicoLitigantes = juridicoLitigante;

                destination.ConyugesLitigante = conyugeLitigante;
            }

            if (source.InfoComplementarios != null)
            {
                destination.InfoComplementario = context.Mapper.Map<InfoComplementarioDto>(source.InfoComplementarios.FirstOrDefault());
            }

            if (source.Declarantes != null && source.Declarantes.Count > 0)
            {
                var declarante = source.Declarantes.FirstOrDefault();

                if (declarante?.Persona != null)
                    destination.DeclaranteInfo = context.Mapper.Map<DeclarantePersonaDto>(source.Declarantes.FirstOrDefault().Persona);
                else destination.DeclaranteInfo = new DeclarantePersonaDto();

                destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(source.Declarantes.FirstOrDefault().CondicionPer);
                destination.DeclaranteInfo.NumeroDni = source.Declarantes.FirstOrDefault().Persona.NumeroDoc;
                destination.DeclaranteInfo.IdDeclarante = source.Declarantes.FirstOrDefault().IdDeclarante;
                destination.DeclaranteInfo.Fecha = source.Declarantes.FirstOrDefault().Fecha;
                destination.DeclaranteInfo.TieneFirma = source.Declarantes.FirstOrDefault().TieneFirma;
            }

            if (source.Supervisores != null && source.Supervisores.Count > 0)
            {
                destination.SupervisorInfo = context.Mapper.Map<SupervisorPersonaDto>(source.Supervisores.FirstOrDefault().Persona);
                destination.SupervisorInfo.IdSupervisor = source.Supervisores.FirstOrDefault().IdSupervisor;
                destination.SupervisorInfo.NumeroDni = source.Supervisores.FirstOrDefault().Persona.NumeroDoc;
                destination.SupervisorInfo.Fecha = source.Supervisores.FirstOrDefault().Fecha;
                destination.SupervisorInfo.TieneFirma = source.Supervisores.FirstOrDefault().TieneFirma;
            }

            if (source.TecnicoCatastrales != null && source.TecnicoCatastrales.Count > 0)
            {
                destination.TecnicoInfo = context.Mapper.Map<TecnicoCatastralPersonaDto>(source.TecnicoCatastrales.FirstOrDefault().Persona);
                destination.TecnicoInfo.NumeroDni = source.TecnicoCatastrales.FirstOrDefault().Persona.NumeroDoc;
                destination.TecnicoInfo.IdTecnico = source.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;
                destination.TecnicoInfo.Fecha = source.TecnicoCatastrales.FirstOrDefault().Fecha;
                destination.TecnicoInfo.TieneFirma = source.TecnicoCatastrales.FirstOrDefault().TieneFirma;
            }

            if (source.VerificadorCatastrales != null && source.VerificadorCatastrales.Count > 0)
            {
                destination.VerificadorCatastral = context.Mapper.Map<VerificadorCatastralDto>(source.VerificadorCatastrales.FirstOrDefault().Persona);
                destination.VerificadorCatastral.Id = source.VerificadorCatastrales.FirstOrDefault().Id;
                destination.VerificadorCatastral.NumeroDni = source.VerificadorCatastrales.FirstOrDefault().Persona.NumeroDoc;
                destination.VerificadorCatastral.Fecha = source.VerificadorCatastrales.FirstOrDefault().Fecha;
                destination.VerificadorCatastral.TieneFirma = source.VerificadorCatastrales.FirstOrDefault().TieneFirma;
                destination.VerificadorCatastral.NumeroRegistro = source.VerificadorCatastrales.FirstOrDefault().NumeroRegistro;
            }

            if (source.EvaluacionPredioCatastrales != null && source.EvaluacionPredioCatastrales.Count > 0)
            {
                destination.EvaluacionPredioCatastral = context.Mapper.Map<EvaluacionPredioCatastralDto>(source.EvaluacionPredioCatastrales.FirstOrDefault());
            }
            
            if (source.AreaTerrenoInvalids != null && source.AreaTerrenoInvalids.Count > 0)
            {
                destination.AreaTerrenoInvalid = context.Mapper.Map<AreaTerrenoInvalidDto>(source.AreaTerrenoInvalids.FirstOrDefault());
            }
        }
    }
}
