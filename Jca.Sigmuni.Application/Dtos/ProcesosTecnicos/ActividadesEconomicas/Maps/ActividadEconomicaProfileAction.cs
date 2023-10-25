using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesConductores;
using Jca.Sigmuni.Application.Dtos.General.Supervisores;
using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AreaActividadesEconomicas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesAnuncios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.InfoComplementarios;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas.Maps
{
    public class ActividadEconomicaProfileAction : IMappingAction<Ficha, ActividadEconomicaDto>
    {
        private readonly IUbigeoRepository _ubigeoRepository;

        public ActividadEconomicaProfileAction(IUbigeoRepository ubigeoRepository)
        {
            _ubigeoRepository = ubigeoRepository;
        }

        public void Process(Ficha source, ActividadEconomicaDto destination, ResolutionContext context)
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

                if (source.Conductores != null && source.Conductores.Count > 0)
                {

                    if (source.Conductores.FirstOrDefault().Persona != null)
                    {
                        destination.ConductorPersona = context.Mapper.Map<ConductorDto>(source.Conductores.FirstOrDefault().Persona);
                        destination.ConductorPersona.IdPersona = source.Conductores.FirstOrDefault().Persona.Id;
                        destination.ConductorPersona.NumeroDni = source.Conductores.FirstOrDefault().Persona.NumeroDoc;
                        destination.ConductorPersona.NumeroRuc = source.Conductores.FirstOrDefault().Persona.NumeroRuc;
                        destination.ConductorPersona.IdConductor = source.Conductores.FirstOrDefault().IdConductor;
                        destination.ConductorPersona.NombreAsociacion = source.Conductores.FirstOrDefault().NombreAsociacion;
                        destination.ConductorPersona.NombreComercial = source.Conductores.FirstOrDefault().NombreComercial;
                        destination.ConductorPersona.NumTrabajadores = source.Conductores.FirstOrDefault().NumTrabajadores;

                        if(source.Conductores.FirstOrDefault().Persona.InfoContacto != null)
                        {
                            destination.ConductorPersona.Contacto = context.Mapper.Map<InfoContactoDto>(source.Conductores.FirstOrDefault().Persona.InfoContacto.FirstOrDefault());
                        }

                        if (source.Conductores.FirstOrDefault().CondicionConductor != null)
                        {
                            destination.ConductorPersona.CondConductor = context.Mapper.Map<CondicionConductorDto>(source.Conductores.FirstOrDefault().CondicionConductor);
                        }

                        if (source.Conductores.FirstOrDefault().Persona.RepresentanteLegalDD != null)
                        {
                            destination.Representante = context.Mapper.Map<RepresentanteConductorDto>(source.Conductores.FirstOrDefault().Persona.RepresentanteLegalDD);
                        }

                        if (source.Conductores.FirstOrDefault().Persona.Domicilio != null)
                        {
                            destination.DomicilioConductor = context.Mapper.Map<DomicilioConductorDto>(source.Conductores.FirstOrDefault().Persona.Domicilio.FirstOrDefault());

                            if (destination.DomicilioConductor != null)
                            {
                                destination.DomicilioConductor.NumeroInterior = source.Conductores.FirstOrDefault().Persona.Domicilio.FirstOrDefault().NumInterior;
                                destination.DomicilioConductor.HabilitacionesUrbanas = context.Mapper.Map<HabilitacionUrbanaFichaDto>(source.Conductores.FirstOrDefault().Persona.Domicilio.FirstOrDefault().HabilitacionUrbana);
                                //if (destination.DomicilioConductor.Ubigeo != null)
                                //{
                                //    var provincia = _ubigeoRepositorio.BuscarPorCodigoAsync(destination.DomicilioConductor.Ubigeo.CodigoPadre);

                                //    if (provincia.Result != null)
                                //    {
                                //        destination.DomicilioConductor.Provincia = context.Mapper.Map<UbigeoDto>(provincia.Result);

                                //        var departamento = _ubigeoRepositorio.BuscarPorCodigoAsync(provincia.Result.CodigoPadre);
                                //        if (departamento.Result != null)
                                //        {
                                //            destination.DomicilioConductor.Departamento = context.Mapper.Map<UbigeoDto>(departamento.Result);
                                //        }
                                //    }

                                //}

                            }
                        }
                    }
                }

                if (source.AreaActividadEconomicas != null && source.AreaActividadEconomicas.Count > 0)
                {
                    destination.AreaActEconomica = context.Mapper.Map<AreaActividadEconomicaDto>(source.AreaActividadEconomicas.FirstOrDefault());
                }

                if (source.AutorizacionMunicipales != null && source.AutorizacionMunicipales.Count > 0)
                {
                    destination.AutorizacionMunicipal = context.Mapper.Map<List<AutorizacionMunicipalDto>>(source.AutorizacionMunicipales);
                }

                if (source.AutorizacionAnuncios != null && source.AutorizacionAnuncios.Count > 0)
                {
                    destination.AutorizacionAnuncio = context.Mapper.Map<List<AutorizacionAnuncioDto>>(source.AutorizacionAnuncios);
                }

                if (source.InfoComplementarios.Count > 0 )
                {
                    destination.InfoComplementaria = context.Mapper.Map<InfoComplementarioDto>(source.InfoComplementarios.FirstOrDefault());
                }

                if (source.Declarantes != null && source.Declarantes.Count > 0)
                {
                    destination.DeclaranteInfo = context.Mapper.Map<DeclarantePersonaDto>(source.Declarantes.FirstOrDefault().Persona);
                    if (source.Declarantes.FirstOrDefault().CondicionPer != null && destination.DeclaranteInfo != null)
                    {
                        var condicionPer = source.Declarantes.FirstOrDefault().CondicionPer;
                        destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(condicionPer);
                    }
                    if (destination.DeclaranteInfo != null)
                    {
                        destination.DeclaranteInfo.IdDeclarante = source.Declarantes.FirstOrDefault().IdDeclarante;
                        destination.DeclaranteInfo.Fecha = source.Declarantes.FirstOrDefault().Fecha;
                        destination.DeclaranteInfo.TieneFirma = source.Declarantes.FirstOrDefault().TieneFirma;
                    }
                    if (source.Declarantes.FirstOrDefault().CondicionPer != null && source.Declarantes.FirstOrDefault().Persona == null)
                    {
                        var condicionPer = source.Declarantes.FirstOrDefault().CondicionPer;
                        destination.DeclaranteInfo = new DeclarantePersonaDto();
                        destination.DeclaranteInfo.CondicionPer = context.Mapper.Map<CondicionPerDto>(condicionPer);
                    }
                }

                if (source.Supervisores != null && source.Supervisores.Count > 0)
                {
                    destination.SupervisorInfo = context.Mapper.Map<SupervisorPersonaDto>(source.Supervisores.FirstOrDefault().Persona);
                    if (destination.SupervisorInfo != null)
                    {
                        destination.SupervisorInfo.IdSupervisor = source.Supervisores.FirstOrDefault().IdSupervisor;
                        destination.SupervisorInfo.Fecha = source.Supervisores.FirstOrDefault().Fecha;
                        destination.SupervisorInfo.TieneFirma = source.Supervisores.FirstOrDefault().TieneFirma;
                    }
                }

                if (source.TecnicoCatastrales != null && source.TecnicoCatastrales.Count > 0)
                {
                    destination.TecnicoInfo = context.Mapper.Map<TecnicoCatastralPersonaDto>(source.TecnicoCatastrales.FirstOrDefault().Persona);
                    if (destination.TecnicoInfo != null)
                    {
                        destination.TecnicoInfo.IdTecnico = source.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;
                        destination.TecnicoInfo.Fecha = source.TecnicoCatastrales.FirstOrDefault().Fecha;
                        destination.TecnicoInfo.TieneFirma = source.TecnicoCatastrales.FirstOrDefault().TieneFirma;
                    }
                }
            }
        }
    }
}
