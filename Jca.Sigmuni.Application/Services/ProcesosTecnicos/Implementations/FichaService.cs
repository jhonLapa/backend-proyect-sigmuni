using AutoMapper;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesEconomicas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.BienesCulturales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaBusquedas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDeclaratorias;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoMantenimientos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Services.Admins.Abstractions;
using Jca.Sigmuni.Application.Services.General.Abstractions;
using Jca.Sigmuni.Application.Services.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Core.Paginations;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.ProcesosTecnicos.Enums;
using Jca.Sigmuni.Infraestructure.Repositories.Admins.Abastractions;
using Jca.Sigmuni.Infraestructure.Repositories.General.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.ProcesosTecnicos.Abstractions;
using Jca.Sigmuni.Infraestructure.Repositories.Zonificaciones.Abstractions;
using Jca.Sigmuni.Util.Flags;

namespace Jca.Sigmuni.Application.Services.ProcesosTecnicos.Implementations
{
    public class FichaService : IFichaService
    {
        private readonly IMapper _mapper;
        private readonly ILoteRepository _loteRepository;
        private readonly IUnidadCatastralRepository _unidadCatastralRepository;
        private readonly IUnidadCatastralService _unidadCatastralService;
        private readonly IFichaRepository _fichaRepository;
        private readonly ITblCodigoService _tblCodigoService;
        private readonly IFichaBienCulturalService _fichaBienCulturalService;
        private readonly ITipoEdificacionRepository _tipoEdificacionRepository;
        private readonly ITipoAgrupacionRepository _tipoAgrupacionRepository;
        private readonly IEdificacionRepository _edificacionRepository;
        private readonly IEdificacionService _edificacionService;
        private readonly IUbicacionPredioService _ubicacionPredioService;
        private readonly IPuertaService _viaPuertaService;
        private readonly ICaracteristicaTitularidadService _caracteristicaTitularidadService;
        private readonly ITitularCatastralService _titularCatastralService;
        private readonly IDomicilioRepository _domicilioRepository;
        private readonly IUbigeoRepository _ubigeoRepository;
        private readonly ILoteZonificacionParametroRepository _loteZonificacionParametroRepository;
        private readonly IDescripcionPredioService _descripcionPredioService;
        private readonly IEvaluacionPredioService _evaluacionPredioService;
        private readonly IServicioBasicoService _servicioBasicoService;
        private readonly IConstruccionService _construccionService;
        private readonly ITipoDeclaratoriaRepository _tipoDeclaratoriaRepository;
        private readonly ITipoTituloInscritoRepository _tipoTituloInscritoRepository;
        private readonly ISunarpService _sunarpService;
        private readonly IFichaIndividualService _fichaIndividualService;
        private readonly IOtraInstalacionService _otraInstalacionService;
        private readonly IFichaDocumentoService _fichaDocumentoService;
        private readonly IRegistroLegalService _registroLegalService;
        private readonly ILitiganteService _litiganteService;
        private readonly ILitiganteRepository _litiganteRepository;
        private readonly IDependienteService _dependienteService;
        private readonly ITipoMantenimientoRepository _tipoMantenimientoRepository;
        private readonly IInfoComplementarioService _infoComplementarioService;
        private readonly IDeclaranteService _declaranteService;
        private readonly ISupervisorService _supervisorService;
        private readonly ITecnicoCatastralService _tecnicoCatastralService;
        private readonly IOcupanteService _ocupanteService;
        private readonly INormaIntMonPrehiService _normaIntMonPreinsService;
        private readonly IMonumentoPrehispanicoService _monumentoPrehispanicoService;
        private readonly INormaIntMonColonialService _normaIntMonColonialService;
        private readonly IRecapitulacionEdificioService _recapitulacionEdificioService;
        private readonly IRecapitulacionBienComunService _recapitulacionBienComunService;
        private readonly IRecapBienComunComplementarioService _recapBienComunComplementarioService;
        private readonly IMonumentoColonialService _monumentoColonialService;
        private readonly IConductorService _conductorService;
        private readonly IAutorizacionAnuncioService _autorizacionAnuncioService;
        private readonly IDomicilioService _domicilioService;
        private readonly IAutorizacionMunicipalService _autorizacionMunicipalService;
        private readonly IAreaActividadEconomicaService _areaActividadEconomicaService;
        private readonly IEvaluacionPredioCatastralService _evaluacionPredioCatastralService;
        private readonly IVerificadorCatastralService _verificadorCatastralService;
        private readonly IAreaTerrenoInvalidService _areaTerrenoInvalidService;
        private readonly IExoneracionTitularService _exoneracionTitularService;


        public FichaService(IMapper mapper, 
                            ILoteRepository loteRepository, 
                            IUnidadCatastralRepository unidadCatastralRepository,
                            IUnidadCatastralService unidadCatastralService,
                            IFichaRepository fichaRepository,
                            IFichaBienCulturalService fichaBienCulturalService,
                            ITblCodigoService tblCodigoService,
                            ITipoEdificacionRepository tipoEdificacionRepository,
                            ITipoAgrupacionRepository tipoAgrupacionRepository,
                            IEdificacionRepository edificacionRepository,
                            IEdificacionService edificacionService,
                            IUbicacionPredioService ubicacionPredioService,
                            IPuertaService viaPuertaService,
                            ICaracteristicaTitularidadService caracteristicaTitularidadService,
                            ITitularCatastralService titularCatastralService,
                            IDomicilioRepository domicilioRepository,
                            IUbigeoRepository ubigeoRepository,
                            ILoteZonificacionParametroRepository loteZonificacionParametroRepository,
                            IDescripcionPredioService descripcionPredioService,
                            IEvaluacionPredioService evaluacionPredioService,
                            IServicioBasicoService servicioBasicoService,
                            IConstruccionService construccionService,
                            ITipoDeclaratoriaRepository tipoDeclaratoriaRepository,
                            ITipoTituloInscritoRepository tipoTituloInscritoRepository,
                            ISunarpService sunarpService,
                            IFichaIndividualService fichaIndividualService,
                            IOtraInstalacionService otraInstalacionService,
                            IFichaDocumentoService fichaDocumentoService,
                            IRegistroLegalService registroLegalService,
                            ILitiganteService litiganteService,
                            ILitiganteRepository litiganteRepository,
                            IDependienteService dependienteService,
                            ITipoMantenimientoRepository tipoMantenimientoRepository,
                            IInfoComplementarioService infoComplementarioService,
                            IDeclaranteService declaranteService,
                            ISupervisorService supervisorService,
                            ITecnicoCatastralService tecnicoCatastralService,
                            IOcupanteService ocupanteService,
                            INormaIntMonPrehiService normaIntMonPreinsService,
                            IMonumentoPrehispanicoService monumentoPrehispanicoService,
                            INormaIntMonColonialService normaIntMonColonialService,
                            IRecapitulacionEdificioService recapitulacionEdificioService,
                            IRecapitulacionBienComunService recapitulacionBienComunService,
                            IRecapBienComunComplementarioService recapBienComunComplementarioService,
                            IMonumentoColonialService monumentoColonialService,
                            IConductorService conductorService,
                            IAutorizacionAnuncioService autorizacionAnuncioService,
                            IDomicilioService domicilioService,
                            IAutorizacionMunicipalService autorizacionMunicipalService,
                            IAreaActividadEconomicaService areaActividadEconomicaService,
                            IEvaluacionPredioCatastralService evaluacionPredioCatastralService,
                            IVerificadorCatastralService verificadorCatastralService,
                            IAreaTerrenoInvalidService areaTerrenoInvalidService,
                            IExoneracionTitularService exoneracionTitularService)

        {
            _mapper = mapper;
            _loteRepository = loteRepository;
            _unidadCatastralRepository = unidadCatastralRepository;
            _unidadCatastralService = unidadCatastralService;
            _fichaBienCulturalService = fichaBienCulturalService;
            _fichaRepository = fichaRepository;
            _tblCodigoService = tblCodigoService;
            _tipoEdificacionRepository = tipoEdificacionRepository;
            _tipoAgrupacionRepository = tipoAgrupacionRepository;
            _edificacionRepository = edificacionRepository;
            _edificacionService = edificacionService;
            _ubicacionPredioService = ubicacionPredioService;
            _viaPuertaService = viaPuertaService;
            _caracteristicaTitularidadService = caracteristicaTitularidadService;
            _titularCatastralService = titularCatastralService;
            _domicilioRepository = domicilioRepository;
            _ubigeoRepository = ubigeoRepository;
            _loteZonificacionParametroRepository = loteZonificacionParametroRepository;
            _descripcionPredioService = descripcionPredioService;
            _evaluacionPredioService = evaluacionPredioService;
            _servicioBasicoService = servicioBasicoService;
            _construccionService = construccionService;
            _tipoDeclaratoriaRepository = tipoDeclaratoriaRepository;
            _tipoTituloInscritoRepository = tipoTituloInscritoRepository;
            _sunarpService = sunarpService;
            _fichaIndividualService = fichaIndividualService;
            _otraInstalacionService = otraInstalacionService;
            _fichaDocumentoService = fichaDocumentoService;
            _registroLegalService = registroLegalService;
            _litiganteService = litiganteService;
            _litiganteRepository = litiganteRepository;
            _dependienteService = dependienteService;
            _tipoMantenimientoRepository = tipoMantenimientoRepository;
            _infoComplementarioService = infoComplementarioService;
            _declaranteService = declaranteService;
            _supervisorService = supervisorService;
            _tecnicoCatastralService = tecnicoCatastralService;
            _ocupanteService = ocupanteService;
            _tblCodigoService = tblCodigoService;
            _normaIntMonPreinsService = normaIntMonPreinsService;
            _monumentoPrehispanicoService = monumentoPrehispanicoService;
            _normaIntMonColonialService = normaIntMonColonialService;
            _recapitulacionEdificioService = recapitulacionEdificioService;
            _recapitulacionBienComunService = recapitulacionBienComunService;
            _recapBienComunComplementarioService = recapBienComunComplementarioService;
            _monumentoColonialService = monumentoColonialService;
            _conductorService = conductorService;
            _autorizacionAnuncioService = autorizacionAnuncioService;
            _domicilioService = domicilioService;
            _autorizacionMunicipalService = autorizacionMunicipalService;
            _areaActividadEconomicaService = areaActividadEconomicaService;
            _evaluacionPredioCatastralService = evaluacionPredioCatastralService;
            _verificadorCatastralService = verificadorCatastralService;
            _areaTerrenoInvalidService= areaTerrenoInvalidService;
            _exoneracionTitularService = exoneracionTitularService;
        }
        //Individual
        public async Task<int> GuardarFichaIndividualAsync(IndividualFormDto peticion)
        {
            var lote = await _loteRepository.Find(peticion.UnidadCatastral?.IdLoteCarto);
            if (lote == null) throw new Exception("El lote ingresado no existe, verifique por favor");

            if (lote.CUC == null) 
            {
                var loteMaximo = await _loteRepository.BuscarCucMaximo();
                var CUCMax = Convert.ToInt64(loteMaximo.CUC) + 1;

                if (CUCMax > 42706282) throw new Exception("El CUC EXCEDE AL NUMERO MAXIMO");

                lote.CUC = CUCMax.ToString();
                await _loteRepository.EditLote(lote);
            }

            UnidadCatastral unidadCatastral = null;
            if (peticion.UnidadCatastral?.IdUnidadCatastral != 0)
            {
                unidadCatastral = await _unidadCatastralRepository.Find(peticion.UnidadCatastral.IdUnidadCatastral);
            }
            else
            {
                var codigoCatastral = peticion.CodigoCatastral;
                var tblCod = new TblCodigo()
                {
                    CodDistrito = codigoCatastral.CodDistrito,
                    CodSector = codigoCatastral.CodSector,
                    CodManzana = codigoCatastral.CodManzana,
                    CodLote = codigoCatastral.CodLote,
                    CodEdif = codigoCatastral.CodEdif,
                    CodEnt = codigoCatastral.CodEnt,
                    CodPiso = codigoCatastral.CodPiso,
                    CodUnid = codigoCatastral.CodUnid,
                };

                unidadCatastral = await _unidadCatastralRepository.ObtenerPorCodigoCatastralAsync(tblCod);
            }

            if (unidadCatastral == null)
            {
                var unidad = await _unidadCatastralService.Create(peticion.UnidadCatastral);
                //if (!unidad.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, unidad.Mensajes);

                unidadCatastral = await _unidadCatastralRepository.Find(unidad.IdUnidadCatastral);
            }

            if (peticion.Ficha?.IdFicha == null || peticion.Ficha?.IdFicha == 0)
            {
                // Asinar estado a una ficha nueva
                peticion.Ficha.Estado = (int)EstadoFicha.Dinamico;

                // Verificar si existe una ficha individidual dinamica
                var fichaDinamica = await _fichaRepository.ObtenerPorIdUnidadEstadoFichaIdTipoAsync(unidadCatastral.IdUnidadCatastral, EstadoFicha.Dinamico, TipoFichaEnum.Individual);

                //if (fichaDinamica != null) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "Ya exite una ficha dinamica para esta Unidad");
            }

            // Asignamos valores a la ficha para asegurar la consistencia
            peticion.Ficha.IdUnidadCatastral = unidadCatastral.IdUnidadCatastral;
            peticion.Ficha.IdTipoFicha = (int)TipoFichaEnum.Individual;

            var fichaRespuesta = await CrearOActualizarFichaAsync(peticion.Ficha, peticion.Ficha.Estado);
            //if (!fichaRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, fichaRespuesta.Mensajes);
            if (peticion.Ficha.Estado == (int)EstadoFicha.Dinamico && (peticion.Ficha.IdFicha == null || peticion.Ficha.IdFicha == 0)) // habilitar luego de cambiar el estado bool a numerico en la tabla
            {
                await CrearOActualizarFichaAsync(peticion.Ficha, (int)EstadoFicha.Estatico); // se crea una ficha estatica para las nueva ficha dinamica que se crea, y se pueda mandar a CC
            }

            var ficha = await _fichaRepository.Find(fichaRespuesta.IdFicha);

            var idTblCodigo = default(int);
            if (peticion.CodigoCatastral != null)
            {
                peticion.CodigoCatastral.IdUnidadCatastral = unidadCatastral.IdUnidadCatastral;
                var tblCodigo = await _tblCodigoService.CrearOActualizarCodigoCatastralAsync(peticion.CodigoCatastral);
                //if (!tblCodigo.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigo.Mensajes);

                idTblCodigo = tblCodigo.IdTblCodigo;
            }

            if (peticion.CodigoCatastralRef != null)
            {
                peticion.CodigoCatastralRef.IdUnidadCatastral = unidadCatastral.IdUnidadCatastral;
                var tblCodigoRef = await _tblCodigoService.CrearOActualizarCodigoCatastralReferencialAsync(peticion.CodigoCatastralRef);
                //if (!tblCodigoRef.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigoRef.Mensajes);
            }

            //var idUbicacion = default(int);
            //var idEdificacion = default(int);
            ////await _fichaRepositorio.UnidadDeTrabajo.Entry(ficha).Collection(e => e.UbicacionPredio).LoadAsync(); // lo trae el repository
            //if (ficha.UbicacionPredios?.Count > 0)
            //{
            //    var ubicacionPredio = ficha.UbicacionPredios.FirstOrDefault();

            //    if (ubicacionPredio.IdUbicacionPredio != 0) idUbicacion = ubicacionPredio.IdUbicacionPredio;

            //    if (ubicacionPredio.IdEdificacion != null) idEdificacion = ubicacionPredio.IdEdificacion;
            //}

            if (peticion.Edificacion != null)
            {
                //peticion.Edificacion.IdEdificacion = idEdificacion;

                //#region "Busqueda edificacion"
                //if (peticion.Edificacion?.IdEdificacion != null)
                //{
                //    var dtoEdificacion = peticion.Edificacion;

                //    var edificacion = new Edificacion();

                //    edificacion.Manzana = dtoEdificacion.Manzana;
                //    edificacion.Nombre = dtoEdificacion.Nombre;
                //    edificacion.NumLote = dtoEdificacion.NumLote;
                //    edificacion.LoteUrbano = dtoEdificacion.LoteUrbano;
                //    edificacion.SubLote = dtoEdificacion.SubLote;

                //    if (dtoEdificacion.TipoEdificacion != null) edificacion.IdTipoEdificacion = dtoEdificacion.TipoEdificacion.IdTipoEdificacion;
                //    else
                //    {
                //        var tipoEdificacionDefaul = await _tipoEdificacionRepository.TipoEdificacionDefaultAsync();
                //        edificacion.IdTipoEdificacion = tipoEdificacionDefaul?.IdTipoEdificacion;
                //    }

                //    if (dtoEdificacion.TipoAgrupacion != null) edificacion.IdTipoAgrupacion = dtoEdificacion.TipoAgrupacion.IdTipoAgrupacion;
                //    else
                //    {
                //        var tipoAgrupacionDefaul = await _tipoAgrupacionRepository.TipoAgrupacionDefaultAsync();
                //        edificacion.IdTipoAgrupacion = tipoAgrupacionDefaul?.IdTipoAgrupacion;
                //    }

                //    var edificacionEntidad = await _edificacionRepository.BuscarPorEdificacionAsync(edificacion);

                //    if (edificacionEntidad != null) peticion.Edificacion.IdEdificacion = edificacionEntidad.IdEdificacion;
                //}
                //#endregion "Busqueda edificacion"

                var edificacionRespuesta = await _edificacionService.CrearOActualizarAsync(peticion.Edificacion);
                //if (!edificacionRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, edificacionRespuesta.Mensajes);

                if (peticion.Ubicacion != null)
                {
                    //peticion.Ubicacion.IdEdificacion = idUbicacion;
                    peticion.Ubicacion.IdEdificacion = edificacionRespuesta.IdEdificacion;
                    peticion.Ubicacion.IdFicha = ficha.IdFicha;

                    var ubicacionPredio = await _ubicacionPredioService.CrearOActualizarAsync(peticion.Ubicacion);
                    //if (!ubicacionPredio.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, ubicacionPredio.Mensajes);

                    if (peticion.Puertas != null)
                    {
                        var puertasBackend = await _viaPuertaService.ListarPorUbicacionPredioAsync(ubicacionPredio.IdUbicacionPredio);

                        var puertasParaEliminar = puertasBackend.Where(e => !peticion.Puertas.Any(p => p.IdPuerta == e.IdPuerta)).ToList();
                        var puertasParaActualizar = peticion.Puertas.Where(e => puertasBackend.Any(p => p.IdPuerta == e.IdPuerta)).ToList();
                        var puertasParaRegistrar = peticion.Puertas.Where(e => e.IdPuerta == null || e.IdPuerta == 0).ToList();

                        // Verificar si un id_puerta existe en domicilio fiscal
                        if (peticion.DomicilioTitular != null)
                        {
                            foreach (var item in puertasParaEliminar)
                            {
                                if (item.IdPuerta == peticion.DomicilioTitular.IdPuerta)
                                {
                                    peticion.DomicilioTitular.IdPuerta = null;
                                }
                            }
                        }

                        // Eliminar
                        await _viaPuertaService.EliminarPorListaAsync(puertasParaEliminar);

                        // Actualizar
                        foreach (var item in puertasParaActualizar)
                        {
                            item.IdTblCodigo = idTblCodigo;
                            item.IdUbicacionPredio = ubicacionPredio.IdUbicacionPredio;
                            var puerta = await _viaPuertaService.GuardarAsync(item);
                            //if (puerta != null)
                            //{
                            //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, puerta.Mensajes);
                            //}
                        }

                        // Registrar
                        foreach (var item in puertasParaRegistrar)
                        {
                            item.IdTblCodigo = idTblCodigo;
                            item.IdUbicacionPredio = ubicacionPredio.IdUbicacionPredio;
                            var puerta = await _viaPuertaService.GuardarAsync(item);
                            //if (!puerta.Completado)
                            //{
                            //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, puerta.Mensajes);
                            //}
                        }
                    }
                }
            }

            var idTitularCatastral = default(int);
            var idCaracteristicaTitular = default(int?);
            if (ficha.TitularCatastral?.Count > 0)
            {
                var titularCatastral = ficha.TitularCatastral.FirstOrDefault();
                idTitularCatastral = titularCatastral.IdTitularCatastral;
                if (titularCatastral.IdCaracteristicaTitularidad != null) idCaracteristicaTitular = titularCatastral.IdCaracteristicaTitularidad;
            }

            var idCaracteristicaTitularidad = default(int);

            if (peticion.CaracteristicaTitularidad != null)
            {
                peticion.CaracteristicaTitularidad.IdCaracteristicaTitularidad = idCaracteristicaTitular != null ? (int)idCaracteristicaTitular : 0;
                var caracteristicaTitularidad = await _caracteristicaTitularidadService.CrearOActualizarAsync(peticion.CaracteristicaTitularidad);
                //if (!caracteristicaTitularidad.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, caracteristicaTitularidad.Mensajes);

                idCaracteristicaTitularidad = caracteristicaTitularidad.IdCaracteristicaTitularidad;
            }

            if (peticion.CaracteristicaTitularidad?.CondicionTitular?.Descripcion == "COTITULARIDAD")
            {
                PersonaTitularDto titularCatastralAux = new PersonaTitularDto();
                titularCatastralAux.IdFicha = ficha.IdFicha;
                titularCatastralAux.IdCaracteristicaTitularidad = idCaracteristicaTitularidad;

                await _titularCatastralService.CrearCotitularAsync(titularCatastralAux);
            }
            else
            {
                PersonaTitularDto titularCatastralAux = new PersonaTitularDto();
                titularCatastralAux.IdFicha = ficha.IdFicha;
                titularCatastralAux.IdCaracteristicaTitularidad = idCaracteristicaTitularidad;
                await _titularCatastralService.EliminarCotitularAsync(titularCatastralAux);
            }

            if (peticion.Titular != null)
            {
                peticion.Titular.IdTitularCatastral = idTitularCatastral;
                peticion.Titular.IdFicha = ficha.IdFicha;
                peticion.Titular.IdCaracteristicaTitularidad = idCaracteristicaTitularidad != 0 ? idCaracteristicaTitularidad : null;


                var titularRespuesta = await _titularCatastralService.GuardarPersonaTitularAsync(peticion.Titular);
                //if (!titularRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, titularRespuesta.Mensajes);

                var idPersona = peticion.Titular?.IdPersona != 0 && peticion.Titular?.IdPersona != null  ? peticion.Titular.IdPersona : 0;
                var entidadDomicilio = await _domicilioRepository.BusquedaSimplePorIdPersonaAsync(idPersona);
                if (entidadDomicilio == null)
                {
                    var edificacionDefault = await _edificacionRepository.EdificacionDefaultAsync();
                    var ubigeoDefault = await _ubigeoRepository.UbigeoDefaultAsync();

                    entidadDomicilio = new Domicilio();

                    entidadDomicilio.IdPersona = idPersona;
                    entidadDomicilio.CodigoUbigeo = ubigeoDefault.Codigo;
                    entidadDomicilio.IdEdificacion = edificacionDefault?.IdTipoEdificacion;

                    await _domicilioRepository.Create(entidadDomicilio);

                    // verificar
                    // entidadDomicilio = _domicilioRepositorio.BuscarPorId(entidadDomicilio.Id);
                }

                if(peticion.ExoneracionTitular != null)
                {
                    await _exoneracionTitularService.CrearExoneracion(peticion.ExoneracionTitular, idPersona);
                }

                entidadDomicilio.IdPuerta = peticion.DomicilioTitular?.IdPuerta != 0 && peticion.DomicilioTitular?.IdPuerta != null ? peticion.DomicilioTitular.IdPuerta : null;

                await _domicilioRepository.Edit(entidadDomicilio.IdDomicilio, entidadDomicilio);
            }

            if (peticion.DescripcionPredio != null)
            {
                var idDescripcionPredio = default(int);

                if (ficha.DescripcionPredios?.Count > 0) idDescripcionPredio = ficha.DescripcionPredios.FirstOrDefault().IdDescripcionPredio;

                //var loteZonificacion = await _loteZonificacionParametroRepository.BuscarClaseYATNPorIdCartograficoLoteAsync(peticion.UnidadCatastral.IdLoteCarto);

                var areaLibre = default(decimal);
                if (peticion.DescripcionPredio.AreaVerificada.HasValue)
                {
                    areaLibre = peticion.DescripcionPredio.AreaVerificada.Value;

                    if (peticion.Construcciones?.Count > 0)
                    {
                        decimal areaVerificadaConstrucciones = 0;
                        foreach (var item in peticion.Construcciones)
                        {
                            if (int.TryParse(item.NumeroPiso, out int i)) // determina si item.NumeroPiso es un valor númerico válido
                            {
                                if (Int32.Parse(item.NumeroPiso) == 1 && item.Uca.Codigo == "99")
                                {
                                    areaVerificadaConstrucciones += item.AreaVerificada.HasValue ? item.AreaVerificada.Value : 0;
                                }
                            }
                        }
                        areaLibre = peticion.DescripcionPredio.AreaVerificada.Value - areaVerificadaConstrucciones;
                    }
                }

                peticion.DescripcionPredio.IdDescripcionPredio = idDescripcionPredio;
                peticion.DescripcionPredio.IdFicha = ficha.IdFicha;
                //peticion.DescripcionPredio.Zonificacion = loteZonificacion?.ZonificacionParametro?.ClaseZonificacion?.Descripcion ?? "";
                //peticion.DescripcionPredio.Estructuracion = loteZonificacion?.ZonificacionParametro?.AreaTratamiento?.Descripcion ?? "";
                peticion.DescripcionPredio.AreaLibre = areaLibre;
                var descripcionPredio = await _descripcionPredioService.CrearOActualizarAsync(peticion.DescripcionPredio);
                //if (!descripcionPredio.Completado)
                //{
                //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, descripcionPredio.Mensajes);
                //}
            }

            if (peticion.EvaluacionPredio != null)
            {
                var idEvaluacion = default(int);

                if (ficha.EvaluacionPredios.Count > 0) idEvaluacion = ficha.EvaluacionPredios.FirstOrDefault().IdEvaluacionPredio;

                peticion.EvaluacionPredio.IdEvaluacionPredio = idEvaluacion;
                peticion.EvaluacionPredio.IdFicha = ficha.IdFicha;
                await _evaluacionPredioService.CrearOActualizarAsync(peticion.EvaluacionPredio);
            }

            if (peticion.ServicioBasico != null)
            {
                var idServicioBasico = default(int);
                if (ficha.ServicioBasicos.Count > 0) idServicioBasico = ficha.ServicioBasicos.FirstOrDefault().IdServicioBasico;

                peticion.ServicioBasico.IdServicioBasico = idServicioBasico;
                peticion.ServicioBasico.IdFicha = ficha.IdFicha;
                var servicioBasico = await _servicioBasicoService.CrearOActualizarAsync(peticion.ServicioBasico);
                //if (!servicioBasico.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, servicioBasico.Mensajes);
            }

            if (peticion.Construcciones != null)
            {
                await _construccionService.EliminarPorIdFichaAsync(ficha.IdFicha);

                foreach (var item in peticion.Construcciones)
                {
                    item.IdFicha = ficha.IdFicha;
                    var construccion = await _construccionService.CrearAsync(item);
                    //if (!construccion.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, construccion.Mensajes);
                }
            }

            var tipoTituloInscrito = await _tipoTituloInscritoRepository.BuscarPorCodigoAsync(TipoTituloInscritoEnum.DeclaratoriaDeFabrica);
            var fabricaInscrita = await _tipoDeclaratoriaRepository.BuscarPorCodigoAsync(TipoDeclaratoriaEnum.FabricaInscrita);
            var fabricaNoInscrita = await _tipoDeclaratoriaRepository.BuscarPorCodigoAsync(TipoDeclaratoriaEnum.FabricaNoInscrita);

            var idTipoDeclaratoria = default(int?);

            if (peticion.Inscripciones != null)
            {
                await _sunarpService.EliminarPorIdFichaAsync(ficha.IdFicha);

                if (peticion.Inscripciones.Count > 0) idTipoDeclaratoria = fabricaNoInscrita.IdTipoDeclaratoria;

                foreach (var item in peticion.Inscripciones)
                {
                    if (item.TipoTituloInscrito != null)
                    {
                        var id = item.TipoTituloInscrito?.IdTipoTituloInscrito != 0 ? item.TipoTituloInscrito.IdTipoTituloInscrito : new int();
                        if (id == tipoTituloInscrito?.IdTipoTituloInscrito) idTipoDeclaratoria = fabricaInscrita.IdTipoDeclaratoria;
                    }
                    else if (item.TipoTituloInscrito == null)
                    {
                        idTipoDeclaratoria = null;
                    }


                    item.IdFicha = ficha.IdFicha;
                    var sunarp = await _sunarpService.CrearAsync(item);
                    //if (!sunarp.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, sunarp.Mensajes);
                }
            }

            if (peticion.IndividualAdicional != null)
            {
                var idFichaIndividual = default(int);
                if (ficha.FichaIndividuales?.Count > 0) idFichaIndividual = ficha.FichaIndividuales.FirstOrDefault().IdFichaIndividual;

                peticion.IndividualAdicional.IdFichaIndividual = idFichaIndividual;
                peticion.IndividualAdicional.IdFicha = ficha.IdFicha;

                peticion.IndividualAdicional.TipoDeclaratoria = new TipoDeclaratoriaDto
                {
                    Id = idTipoDeclaratoria
                };

                var individualAdicional = await _fichaIndividualService.CrearOActualizarAsync(peticion.IndividualAdicional);
                //if (!individualAdicional.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, individualAdicional.Mensajes);
            }

            if (peticion.OtraInstalaciones?.Count > 0)
            {
                await _otraInstalacionService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.OtraInstalaciones)
                {
                    item.IdFicha = ficha.IdFicha;
                    var otraInstalaciones = await _otraInstalacionService.CrearAsync(item);
                    //if (!otraInstalaciones.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, otraInstalaciones.Mensajes);
                }
            }

            if (peticion.Documentos != null)
            {
                await _fichaDocumentoService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.Documentos)
                {
                    item.IdFicha = ficha.IdFicha;
                    var fichaDocumentoServicio = await _fichaDocumentoService.CrearAsync(item);
                    //if (!fichaDocumentoServicio.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, fichaDocumentoServicio.Mensajes);
                }
            }

            if (peticion.InfoLegal != null)
            {
                await _registroLegalService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.InfoLegal)
                {
                    item.IdFicha = ficha.IdFicha;
                    await _registroLegalService.CrearAsync(item);
                }
            }

            if (peticion.OcupantePersona != null)
            {
                await _ocupanteService.EliminarOcupantesPorIdFichaAsync(ficha.IdFicha);
                peticion.OcupantePersona.IdFicha = ficha.IdFicha;
                var ocupanteRespuesta = await _ocupanteService.GuardarPersonaOcupanteAsync(peticion.OcupantePersona);
                //if (!ocupanteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, ocupanteRespuesta.Mensajes);
            }

            await _litiganteService.EliminarPorIdFichaAsync(ficha.IdFicha);
            if (peticion.Litigantes != null)
            {
                foreach (var item in peticion.Litigantes)
                {
                    item.IdFicha = ficha.IdFicha;
                    var litigante = await _litiganteService.GuardarPersonaLitiganteAsync(item);
                    //if (!litigante.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, litigante.Mensajes);
                }
            }

            if (peticion.ConyugesLitigante != null)
            {
                var litigantes = await _litiganteRepository.ListarPorIdFichaAsync(ficha.IdFicha);
                if (litigantes?.Count > 0)
                {
                    foreach (var item in peticion.ConyugesLitigante)
                    {
                        item.IdLitigante = litigantes.FirstOrDefault().IdLitigante;
                        var conyugueLitigante = await _dependienteService.GuardarConyugeLitiganteAsync(item);
                        //if (!conyugueLitigante.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, conyugueLitigante.Mensajes);
                    }
                }
            }

            if (peticion.JuridicoLitigantes != null)
            {
                foreach (var item in peticion.JuridicoLitigantes)
                {
                    item.IdFicha = ficha.IdFicha;
                    var litiganteJuridico = await _litiganteService.GuardarJuridicoaLitiganteAsync(item);
                    //if (!litiganteJuridico.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, litiganteJuridico.Mensajes);
                }
            }

            if (peticion.InfoComplementario != null)
            {
                //var tipoMantenimiento = await _tipoMantenimientoRepository.BuscarPorCodigoAsync(TipoMantenimientoEnum.PredioCatastralNuevo);

                //var idInformacionComplementaria = default(int);
                //if (ficha.InfoComplementarios.Count > 0)
                //{
                //    idInformacionComplementaria = ficha.InfoComplementarios.FirstOrDefault().IdInfoComplementario;
                //}

                //peticion.InfoComplementario.TipoMantenimiento = new TipoMantenimientoDto
                //{
                //    IdTipoMantenimiento = tipoMantenimiento.IdTipoMantenimiento
                //};

                //peticion.InfoComplementario.IdInfoComplementario = idInformacionComplementaria;
                peticion.InfoComplementario.IdFicha = ficha.IdFicha;
                var infoComplementaria = await _infoComplementarioService.CrearOActualizarAsync(peticion.InfoComplementario);
                //if (!infoComplementaria.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, infoComplementaria.Mensajes);
            }

            if (peticion.DeclaranteInfo != null && (peticion.DeclaranteInfo?.IdPersona != null && peticion.DeclaranteInfo?.IdPersona != 0))
            {
                var idDeclarante = default(int);
                if (ficha.Declarantes.Count > 0) idDeclarante = ficha.Declarantes.FirstOrDefault().IdDeclarante;

                peticion.DeclaranteInfo.IdDeclarante = idDeclarante;
                peticion.DeclaranteInfo.IdFicha = ficha.IdFicha;
                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }
            else if (ficha.Declarantes?.Count > 0)
            {
                var declaranteRespuesta = await _declaranteService.EliminarAsync(ficha.Declarantes.FirstOrDefault().IdDeclarante);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }
            else if (peticion.DeclaranteInfo?.CondicionPer != null && peticion.DeclaranteInfo?.IdPersona != 0)
            {
                peticion.DeclaranteInfo.IdDeclarante = null;
                peticion.DeclaranteInfo.IdFicha = ficha.IdFicha;
                peticion.DeclaranteInfo.TieneFirma = false;
                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            if (peticion.SupervisorInfo != null && peticion.SupervisorInfo?.IdPersona != 0)
            {
                var idSupervisor = default(int);
                if (ficha.Supervisores.Count > 0) idSupervisor = ficha.Supervisores.FirstOrDefault().IdSupervisor;

                peticion.SupervisorInfo.IdSupervisor = idSupervisor;
                peticion.SupervisorInfo.IdFicha = ficha.IdFicha;
                var supervisorRespuesta = await _supervisorService.GuardarPersonaSupervisorAsync(peticion.SupervisorInfo);
                //if (!supervisorRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, supervisorRespuesta.Mensajes);
            }
            else if (ficha.Supervisores.Count > 0)
            {
                var supervisorRespuesta = await _supervisorService.EliminarAsync(ficha.Supervisores.FirstOrDefault().IdSupervisor);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            if (peticion.TecnicoInfo != null && peticion.TecnicoInfo?.IdPersona != 0)
            {
                var idTecnicoCatastral = default(int);
                if (ficha.TecnicoCatastrales.Count > 0) idTecnicoCatastral = ficha.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;

                peticion.TecnicoInfo.IdTecnico = idTecnicoCatastral;
                peticion.TecnicoInfo.IdFicha = ficha.IdFicha;
                var tecnicoRespuesta = await _tecnicoCatastralService.GuardarPersonaTecnicoCatastralAsync(peticion.TecnicoInfo);
                //if (!tecnicoRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tecnicoRespuesta.Mensajes);
            }
            else if (ficha.TecnicoCatastrales.Count > 0)
            {
                var tecnicoRespuesta = await _tecnicoCatastralService.EliminarAsync(ficha.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            if (peticion.EvaluacionPredioCatastral != null)
            {
                var idEvaluacionPredioCatastral = default(int?);
                //if (ficha.EvaluacionPredioCatastrales.Count > 0) idEvaluacionPredioCatastral = ficha.EvaluacionPredioCatastrales?.FirstOrDefault()?.Id ?? 0;

                //peticion.EvaluacionPredioCatastral.Id = idEvaluacionPredioCatastral;
                peticion.EvaluacionPredioCatastral.IdFicha = ficha.IdFicha;
                var servicioBasico = await _evaluacionPredioCatastralService.CrearOActualizarAsync(peticion.EvaluacionPredioCatastral);
                //if (!servicioBasico.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, servicioBasico.Mensajes);
            }

            if(peticion.AreaTerrenoInvalid != null)
            {
                var idEvaluacionPredioCatastral = default(int?);
                peticion.AreaTerrenoInvalid.IdFicha = ficha.IdFicha;
                await _areaTerrenoInvalidService.CreateAreaTerreno(peticion.AreaTerrenoInvalid);
            }

            if(peticion.VerificadorCatastral != null && peticion.VerificadorCatastral.IdPersona != 0)
            {
                //var idVerificadorCatastral = default(int);
                //if (ficha.TecnicoCatastrales.Count > 0) idVerificadorCatastral = ficha.VerificadorCatastrales.FirstOrDefault().Id;

                //peticion.VerificadorCatastral.Id = idVerificadorCatastral;
                peticion.VerificadorCatastral.IdFicha = ficha.IdFicha;
                var tecnicoRespuesta = await _verificadorCatastralService.CrearOActualizarAsync(peticion.VerificadorCatastral);
            }

            return ficha.IdFicha;
        }
        public async Task<IndividualDto> FichaIndividualPorIdAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindByIdAsync(idFicha);

            if (ficha == null) throw new Exception("No se encontró la ficha individual");

            var dto = _mapper.Map<IndividualDto>(ficha);

            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(idFicha, ficha.Estado);

            if(fichasAsociadas.Count > 0)
            {
                List<int> listaIds = new List<int>();
                fichasAsociadas.ForEach(f =>
                {
                    if (f.IdTipoFicha == (int)TipoFichaEnum.Cotitular)
                    {
                        dto.Ficha.IdFichaCotitular = f.IdFicha;
                    }

                    if (f.IdTipoFicha == (int)TipoFichaEnum.ActividadEconomica)
                    {
                        listaIds.Add(f.IdFicha);
                    }

                    if (f.IdTipoFicha == (int)TipoFichaEnum.BienesCulturales)
                    {
                        dto.Ficha.IdFichaBienCultural = f.IdFicha;
                    }

                });
                dto.Ficha.IdsFichasEconomicas = listaIds;
            }

            if (ficha.Estado == (int)EstadoFicha.Dinamico)
            {
                var fichaEstatica = await _fichaRepository.ObtenerPorIdUnidadEstadoFichaIdTipoAsync(ficha.IdUnidadCatastral, EstadoFicha.Estatico, TipoFichaEnum.Individual);
                if (fichaEstatica != null)
                    dto.Ficha.IdFichaIndividualEstatica = fichaEstatica.IdFicha;
            }

            return dto;
        }
        private async Task<Ficha?> CrearOActualizarFichaAsync(FichaDto peticion, int estado)
        {
            var id = peticion.IdFicha;

            var ficha = await _fichaRepository.Find(id);

            if (ficha == null)
            {
                ficha = new Ficha();
            }

            ficha.AnioFicha = peticion.AnioFicha;
            ficha.NumExpediente = peticion.NumExpediente;
            ficha.NtTf = peticion.NtTf;
            ficha.IdLoteCarto = peticion.IdLoteCarto;
            ficha.IdFichaPadre = peticion.IdFichaPadre == null ? null : peticion.IdFichaPadre;
            ficha.IdTipoFicha = peticion.IdTipoFicha;
            ficha.IdUnidadCatastral = peticion.IdUnidadCatastral;
            ficha.AnioFicha = peticion.AnioFicha;
            ficha.TipoBienComun = peticion.TipoBienComun;
            ficha.FechaActualizacion = DateTime.Now;
            ficha.IdUsuario = peticion.IdUsuario;
            ficha.Estado = estado;

            if (ficha.IdFicha == 0)
            {
                var correlativo = $"0001";

                var fichasPorLote = await _fichaRepository.BuscarPorIdLoteCartoYIdTipoAsync(peticion.IdLoteCarto, peticion.IdTipoFicha);
                if (fichasPorLote != null)
                {
                    var UltimaFicha = fichasPorLote.Where(e => e.IdFicha == fichasPorLote.Max(e => e.IdFicha)).FirstOrDefault();
                    if (UltimaFicha != null)
                    {
                        var nroCorrelativo = Convert.ToInt32(!string.IsNullOrWhiteSpace(UltimaFicha.NumFicha) ? UltimaFicha.NumFicha : "0");
                        var cod = $"0000{nroCorrelativo + 1}";
                        cod = cod.Substring(cod.Length - 4);
                        correlativo = cod;
                    }
                }
                ficha.NumFicha = correlativo;
                return await _fichaRepository.Create(ficha);
            }
            else
            {
                return await _fichaRepository.Edit(peticion.IdFicha, ficha);
            }

            //return // consultar
        }
        //Cotitular
        public async Task<FichaCotitularDto> FindFichaCotitularByIdAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindCotitularByIdAsync(idFicha);

            var dto = _mapper.Map<FichaCotitularDto>(ficha);

            return dto;
        }
        public async Task<int> GuardarFichaCotitularAsync(FichaCotitularFormDto peticion)
        {
            var fichaPadre = await _fichaRepository.Find(peticion.Ficha?.IdFichaPadre ?? 0); 
            //if (fichaPadre == null) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "Primero registre una ficha individuala");


            peticion.Ficha.IdTipoFicha = (int)TipoFichaEnum.Cotitular;
            peticion.Ficha.IdUnidadCatastral = fichaPadre.IdUnidadCatastral;
            peticion.Ficha.Estado = fichaPadre.Estado;

            var fichaRespuesta = await CrearOActualizarFichaAsync(peticion.Ficha,2);
           // if (!fichaRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, fichaRespuesta.Mensajes);

            var infoFicha =  await _fichaRepository.Find(fichaRespuesta.IdFicha);

            if (peticion.CodigoCatastral != null)
            {
                peticion.CodigoCatastral.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigo = await _tblCodigoService.CrearOActualizarCodigoCatastralAsync(peticion.CodigoCatastral);
               // if (!tblCodigo.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigo.Mensajes);
            }

            if (peticion.CodigoCatastralRef != null)
            {
                peticion.CodigoCatastralRef.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigoRef = await _tblCodigoService.CrearOActualizarCodigoCatastralReferencialAsync(peticion.CodigoCatastralRef);
                //if (!tblCodigoRef.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigoRef.Mensajes);
            }

            if(infoFicha!= null)
            {
                if (infoFicha.TitularCatastral != null)
                {
                    foreach (var item in infoFicha.TitularCatastral)
                    {
                        await _dependienteService.EliminarPorIdTitularCatastralAsync(item.IdTitularCatastral);
                        await _titularCatastralService.EliminarTitularCatastralAsync(item.IdTitularCatastral);
                        await _caracteristicaTitularidadService.EliminarAsync(item.IdCaracteristicaTitularidad ?? 0);
                    }
                }
            }
            

            if (peticion.Cotitulares != null)
            {
                var correlativoCotitular = 0;
                foreach (var item in peticion.Cotitulares)
                {
                    correlativoCotitular++;
                    var caracteristicaTitularidad = await _caracteristicaTitularidadService.CrearOActualizarAsync(item.CaracteristicaTitularidad);
                    //if (!caracteristicaTitularidad.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, caracteristicaTitularidad.Mensajes);

                    item.Titular.NumTitularidad = correlativoCotitular;
                    item.Titular.IdFicha = infoFicha.IdFicha;
                    item.Titular.IdCaracteristicaTitularidad = caracteristicaTitularidad.IdCaracteristicaTitularidad;

                    var titular = await _titularCatastralService.GuardarPersonaTitularAsync(item.Titular);
                    //if (!titular.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, titular.Mensajes);

                    var idPersona = item.Titular?.IdPersona ?? 0;

                    var entidadDomicilio = await _domicilioRepository.BusquedaSimplePorIdPersonaAsync(idPersona);
                    if (entidadDomicilio == null)
                    {
                        var edificacionDefault = await _edificacionRepository.EdificacionDefaultAsync();
                        var ubigeoDefault = await _ubigeoRepository.UbigeoDefaultAsync();

                        entidadDomicilio = new Domicilio();

                        entidadDomicilio.IdPersona = idPersona;
                        entidadDomicilio.CodigoUbigeo = ubigeoDefault.Codigo;
                        entidadDomicilio.IdEdificacion = edificacionDefault?.IdEdificacion;

                        await _domicilioRepository.Create(entidadDomicilio);
                        
                    }

                    entidadDomicilio.IdPuerta = item.DomicilioTitular?.IdPuerta == 0 || item.DomicilioTitular?.IdPuerta == null ? null : item.DomicilioTitular?.IdPuerta;

                    await _domicilioRepository.Edit(entidadDomicilio.IdDomicilio, entidadDomicilio);
                    
                }
            }

            var tipoMantenimiento = await _tipoMantenimientoRepository.BuscarPorCodigoAsync(TipoMantenimientoEnum.PredioCatastralNuevo);

            if (peticion.InfoComplementario != null)
            {

               // await _fichaRepository.Entry(infoFicha).Collection(e => e.InformacionComplementaria).LoadAsync();
                var idInfoComplementario = default(int);
                if (infoFicha.InfoComplementarios?.Count > 0)
                {
                    idInfoComplementario = infoFicha.InfoComplementarios.FirstOrDefault().IdInfoComplementario;
                }

                var TipoMantenimiento = new TipoMantenimientoDto
                {
                    IdTipoMantenimiento = tipoMantenimiento.IdTipoMantenimiento
                };

                peticion.InfoComplementario.TipoMantenimiento = TipoMantenimiento;

                peticion.InfoComplementario.IdInfoComplementario = idInfoComplementario;
                peticion.InfoComplementario.IdFicha = fichaRespuesta.IdFicha;
                var infoComplementaria = await _infoComplementarioService.CrearOActualizarAsync(peticion.InfoComplementario);
                //if (!infoComplementaria.)
                //{
                //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, infoComplementaria.Mensajes);
                //}
            }

            if (peticion.DeclaranteInfo != null && peticion.DeclaranteInfo?.CondicionPer != null)
            {
                peticion.DeclaranteInfo.IdDeclarante = null;
                peticion.DeclaranteInfo.IdFicha = infoFicha.IdFicha;
                peticion.DeclaranteInfo.TieneFirma = false;

                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                // if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            return infoFicha.IdFicha;
        }
        //Bien Comun
        public async Task<int> GuardarFichaBienComunAsync(BienComunFormDto peticion)
        {
            var idLoteCarto = peticion.CodigoCatastral.CodDistrito + peticion.CodigoCatastral.CodSector + peticion.CodigoCatastral.CodManzana + peticion.CodigoCatastral.CodLote;

            var lote = await _loteRepository.Find(idLoteCarto);
            if (lote == null) throw new Exception("El lote ingresado no existe, verifique por favor");

            UnidadCatastral unidadCatastral = null;
            if (peticion.CodigoCatastral != null && peticion.CodigoCatastral?.IdUnidadCatastral != 0)
            {
                unidadCatastral = await _unidadCatastralRepository.Find(peticion.CodigoCatastral.IdUnidadCatastral);
            }
            else
            {
                var codigoCatastral = peticion.CodigoCatastral;
                var tblCod = new TblCodigo()
                {
                    CodDistrito = codigoCatastral.CodDistrito,
                    CodSector = codigoCatastral.CodSector,
                    CodManzana = codigoCatastral.CodManzana,
                    CodLote = codigoCatastral.CodLote,
                    CodEdif = codigoCatastral.CodEdif,
                    CodEnt = codigoCatastral.CodEnt,
                    CodPiso = codigoCatastral.CodPiso,
                    CodUnid = codigoCatastral.CodUnid,
                };

                unidadCatastral = await _unidadCatastralRepository.ObtenerPorCodigoCatastralAsync(tblCod);
            }

            if (unidadCatastral == null)
            {
                UnidadCatastralFormDto unidadCatastralRegistro = new UnidadCatastralFormDto();
                unidadCatastralRegistro.IdLoteCarto = idLoteCarto;
                if (peticion.UnidadCatastral != null)
                {
                    unidadCatastral = await _unidadCatastralRepository.Find(peticion.UnidadCatastral.IdUnidadCatastral);

                    if (unidadCatastral == null)
                    {
                        var unidad = await _unidadCatastralService.Create(peticion.UnidadCatastral);
                        //if (!unidad.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, unidad.Mensajes);

                        unidadCatastral = await _unidadCatastralRepository.Find(unidad.IdUnidadCatastral);
                    }

                }
                else
                {
                    var unidad = await _unidadCatastralService.Create(unidadCatastralRegistro);
                    //if (!unidad.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, unidad.Mensajes);

                    unidadCatastral = await _unidadCatastralRepository.Find(unidad.IdUnidadCatastral);

                }
            }

            // Asignamos valores a la ficha para asegurar la consistencia
            peticion.Ficha.IdUnidadCatastral = unidadCatastral.IdUnidadCatastral;
            peticion.Ficha.IdTipoFicha = (int)TipoFichaEnum.BienesComunes;

            var fichaRespuesta = await CrearOActualizarFichaAsync(peticion.Ficha, (int)EstadoFicha.Dinamico);
            //if (fichaRespuesta == null) throw new Exception("");

            var ficha = await _fichaRepository.Find(fichaRespuesta.IdFicha);

            var idTblCodigo = default(int);
            if (peticion.CodigoCatastral != null)
            {
                peticion.CodigoCatastral.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigo = await _tblCodigoService.CrearOActualizarCodigoCatastralAsync(peticion.CodigoCatastral);
                //if (!tblCodigo.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigo.Mensajes);

                idTblCodigo = tblCodigo.IdTblCodigo;
            }

            if (peticion.CodigoCatastralRef != null)
            {
                peticion.CodigoCatastralRef.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigoRef = await _tblCodigoService.CrearOActualizarCodigoCatastralReferencialAsync(peticion.CodigoCatastralRef);
                //if (!tblCodigoRef.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigoRef.Mensajes);
            }

            var idUbicacion = default(int);
            var idEdificacion = default(int);

            if (ficha.UbicacionPredios != null && ficha.UbicacionPredios.Count > 0)
            {
                var ubicacionPredio = ficha.UbicacionPredios.FirstOrDefault();

                if (ubicacionPredio.IdUbicacionPredio != 0) idUbicacion = ubicacionPredio.IdUbicacionPredio;

                if (ubicacionPredio.IdEdificacion != null) idEdificacion = ubicacionPredio.IdEdificacion;
            }

            if (peticion.Edificacion != null)
            {
                peticion.Edificacion.IdEdificacion = idEdificacion;

                #region "Busqueda edificacion"
                if (peticion.Edificacion?.IdEdificacion != 0)
                {
                    var dtoEdificacion = peticion.Edificacion;

                    var edificacion = new Edificacion();

                    edificacion.Manzana = dtoEdificacion.Manzana;
                    edificacion.Nombre = dtoEdificacion.Nombre;
                    edificacion.NumLote = dtoEdificacion.NumLote;
                    edificacion.LoteUrbano = dtoEdificacion.LoteUrbano;
                    edificacion.SubLote = dtoEdificacion.SubLote;

                    if (dtoEdificacion.TipoEdificacion != null) edificacion.IdTipoEdificacion = dtoEdificacion.TipoEdificacion.IdTipoEdificacion;
                    else
                    {
                        var tipoEdificacionDefaul = await _tipoEdificacionRepository.TipoEdificacionDefaultAsync();
                        edificacion.IdTipoEdificacion = tipoEdificacionDefaul?.IdTipoEdificacion;
                    }

                    if (dtoEdificacion.TipoAgrupacion != null) edificacion.IdTipoAgrupacion = dtoEdificacion.TipoAgrupacion.IdTipoAgrupacion;
                    else
                    {
                        var tipoAgrupacionDefaul = await _tipoAgrupacionRepository.TipoAgrupacionDefaultAsync();
                        edificacion.IdTipoAgrupacion = tipoAgrupacionDefaul?.IdTipoAgrupacion;
                    }

                    var edificacionEntidad = await _edificacionRepository.BuscarPorEdificacionAsync(edificacion);

                    if (edificacionEntidad != null) peticion.Edificacion.IdEdificacion = edificacionEntidad.IdEdificacion;
                }
                #endregion "Busqueda edificacion"

                var edificacionRespuesta = await _edificacionService.CrearOActualizarAsync(peticion.Edificacion);
                // if (!edificacionRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, edificacionRespuesta.Mensajes);

                if (peticion.Ubicacion != null)
                {
                    peticion.Ubicacion.Id = idUbicacion;
                    peticion.Ubicacion.IdEdificacion = edificacionRespuesta.IdEdificacion;
                    peticion.Ubicacion.IdFicha = ficha.IdFicha;

                    var ubicacionPredio = await _ubicacionPredioService.CrearOActualizarAsync(peticion.Ubicacion);
                    //if (!ubicacionPredio.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, ubicacionPredio.Mensajes);

                    if (peticion.Puertas != null)
                    {
                        var puertasBackend = await _viaPuertaService.ListarPorUbicacionPredioAsync(ubicacionPredio.IdUbicacionPredio);

                        var puertasParaEliminar = puertasBackend.Where(e => !peticion.Puertas.Any(p => p.IdPuerta == e.IdPuerta)).ToList();
                        var puertasParaActualizar = peticion.Puertas.Where(e => puertasBackend.Any(p => p.IdPuerta == e.IdPuerta)).ToList();
                        var puertasParaRegistrar = peticion.Puertas.Where(e => e.IdPuerta != 0 || e.IdPuerta != null).ToList();

                        // Eliminar
                        await _viaPuertaService.EliminarPorListaAsync(puertasParaEliminar);

                        // Actualizar
                        foreach (var item in puertasParaActualizar)
                        {
                            item.IdTblCodigo = idTblCodigo;
                            item.IdUbicacionPredio = ubicacionPredio.IdUbicacionPredio;
                            var puerta = await _viaPuertaService.GuardarAsync(item);
                            //if (!puerta.Completado)
                            //{
                            //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, puerta.Mensajes);
                            //}
                        }

                        // Registrar
                        foreach (var item in puertasParaRegistrar)
                        {
                            item.IdTblCodigo = idTblCodigo;
                            item.IdUbicacionPredio = ubicacionPredio.IdUbicacionPredio;
                            var puerta = await _viaPuertaService.GuardarAsync(item);
                            //if (!puerta.Completado)
                            //{
                            //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, puerta.Mensajes);
                            //}
                        }
                    }
                }
            }

            if (peticion.DescripcionPredio != null)
            {
                var idDescripcionPredio = default(int);

                if (ficha.DescripcionPredios?.Count > 0) idDescripcionPredio = ficha.DescripcionPredios.FirstOrDefault().IdDescripcionPredio;

                //var loteZonificacion = await _loteZonificacionParametroRepository.BuscarClaseYATNPorIdCartograficoLoteAsync(peticion.UnidadCatastral.IdLoteCarto);

                var areaLibre = default(decimal);
                if (peticion.DescripcionPredio.AreaVerificada.HasValue)
                {
                    areaLibre = peticion.DescripcionPredio.AreaVerificada.Value;

                    if (peticion.Construcciones?.Count > 0)
                    {
                        decimal areaVerificadaConstrucciones = 0;
                        foreach (var item in peticion.Construcciones)
                        {
                            if (int.TryParse(item.NumeroPiso, out int i)) // determina si item.NumeroPiso es un valor númerico válido
                            {
                                if (Int32.Parse(item.NumeroPiso) == 1)
                                {
                                    areaVerificadaConstrucciones += item.AreaVerificada.HasValue ? item.AreaVerificada.Value : 0;
                                }
                            }
                        }
                        areaLibre = peticion.DescripcionPredio.AreaVerificada.Value - areaVerificadaConstrucciones;
                    }
                }

                peticion.DescripcionPredio.IdDescripcionPredio = idDescripcionPredio;
                peticion.DescripcionPredio.IdFicha = ficha.IdFicha;
                //peticion.DescripcionPredio.Zonificacion = loteZonificacion?.ZonificacionParametro?.ClaseZonificacion?.Descripcion ?? "";
                //peticion.DescripcionPredio.Estructuracion = loteZonificacion?.ZonificacionParametro?.AreaTratamiento?.Descripcion ?? "";
                peticion.DescripcionPredio.AreaLibre = areaLibre;
                var descripcionPredio = await _descripcionPredioService.CrearOActualizarAsync(peticion.DescripcionPredio);
                //if (!descripcionPredio.Completado)
                //{
                //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, descripcionPredio.Mensajes);
                //}
            }

            if (peticion.EvaluacionPredio != null)
            {
                var idEvaluacion = default(int);

                if (ficha.EvaluacionPredios.Count > 0) idEvaluacion = ficha.EvaluacionPredios.FirstOrDefault().IdEvaluacionPredio;

                peticion.EvaluacionPredio.IdEvaluacionPredio = idEvaluacion;
                peticion.EvaluacionPredio.IdFicha = ficha.IdFicha;
                await _evaluacionPredioService.CrearOActualizarAsync(peticion.EvaluacionPredio);
            }

            if (peticion.ServicioBasico != null)
            {
                var idServicioBasico = default(int);
                if (ficha.ServicioBasicos.Count > 0) idServicioBasico = ficha.ServicioBasicos.FirstOrDefault().IdServicioBasico;

                peticion.ServicioBasico.IdServicioBasico = idServicioBasico;
                peticion.ServicioBasico.IdFicha = ficha.IdFicha;
                var servicioBasico = await _servicioBasicoService.CrearOActualizarAsync(peticion.ServicioBasico);
                //if (!servicioBasico.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, servicioBasico.Mensajes);
            }

            if (peticion.Construcciones != null)
            {
                await _construccionService.EliminarPorIdFichaAsync(ficha.IdFicha);

                foreach (var item in peticion.Construcciones)
                {
                    item.IdFicha = ficha.IdFicha;
                    var construccion = await _construccionService.CrearAsync(item);
                    //if (!construccion.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, construccion.Mensajes);
                }
            }

            var tipoTituloInscrito = await _tipoTituloInscritoRepository.BuscarPorCodigoAsync(TipoTituloInscritoEnum.DeclaratoriaDeFabrica);
            var fabricaInscrita = await _tipoTituloInscritoRepository.BuscarPorCodigoAsync(TipoDeclaratoriaEnum.FabricaInscrita);
            var fabricaNoInscrita = await _tipoTituloInscritoRepository.BuscarPorCodigoAsync(TipoDeclaratoriaEnum.FabricaNoInscrita);

            var idTipoDeclaratoria = default(int?);

            if (peticion.Inscripciones != null)
            {
                await _sunarpService.EliminarPorIdFichaAsync(ficha.IdFicha);

                if (peticion.Inscripciones.Count > 0) idTipoDeclaratoria = fabricaNoInscrita.IdTipoTituloInscrito;

                foreach (var item in peticion.Inscripciones)
                {
                    if (item.TipoTituloInscrito != null)
                    {
                        var id = item.TipoTituloInscrito?.IdTipoTituloInscrito != 0 ? item.TipoTituloInscrito.IdTipoTituloInscrito : new int();
                        if (id == tipoTituloInscrito?.IdTipoTituloInscrito) idTipoDeclaratoria = fabricaInscrita.IdTipoTituloInscrito;
                    }
                    else if (item.TipoTituloInscrito == null)
                    {
                        idTipoDeclaratoria = null;
                    }


                    item.IdFicha = ficha.IdFicha;
                    var sunarp = await _sunarpService.CrearAsync(item);
                    //if (!sunarp.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, sunarp.Mensajes);
                }
            }

            if (peticion.IndividualAdicional != null)
            {
                var idFichaIndividual = default(int);
                if (ficha.FichaIndividuales?.Count > 0) idFichaIndividual = ficha.FichaIndividuales.FirstOrDefault().IdFichaIndividual;

                peticion.IndividualAdicional.IdFichaIndividual = idFichaIndividual;
                peticion.IndividualAdicional.IdFicha = ficha.IdFicha;

                peticion.IndividualAdicional.TipoDeclaratoria = new TipoDeclaratoriaDto
                {
                    Id = idTipoDeclaratoria
                };

                var individualAdicional = await _fichaIndividualService.CrearOActualizarAsync(peticion.IndividualAdicional);
                //if (!individualAdicional.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, individualAdicional.Mensajes);
            }

            if (peticion.OtraInstalaciones?.Count > 0)
            {
                await _otraInstalacionService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.OtraInstalaciones)
                {
                    item.IdFicha = ficha.IdFicha;
                    var otraInstalaciones = await _otraInstalacionService.CrearAsync(item);
                    //if (!otraInstalaciones.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, otraInstalaciones.Mensajes);
                }
            }

            if (peticion.RecapEdificios != null)
            {
                await _recapitulacionEdificioService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.RecapEdificios)
                {
                    item.IdFicha = ficha.IdFicha;
                    var recapitulacionEdificio = await _recapitulacionEdificioService.CrearAsync(item);
                    //if (!recapitulacionEdificio.Completado)
                    //{
                    //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, recapitulacionEdificio.Mensajes);
                    //}
                }
            }

            if (peticion.RecapBienComunes != null)
            {
                await _recapitulacionBienComunService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.RecapBienComunes)
                {
                    item.IdFicha = ficha.IdFicha;
                    var recapitulacionBienComun = await _recapitulacionBienComunService.CrearAsync(item);
                    //if (!recapitulacionBienComun.Completado)
                    //{
                    //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, recapitulacionBienComun.Mensajes);
                    //}
                }
            }

            if (peticion.RecapBienComunComplemetarios != null)
            {
                await _recapBienComunComplementarioService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.RecapBienComunComplemetarios)
                {
                    item.IdFicha = ficha.IdFicha;
                    var recapBienComunComp = await _recapBienComunComplementarioService.CrearAsync(item);
                    //if (!recapBienComunComp.Completado)
                    //{
                    //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, recapBienComunComp.Mensajes);
                    //}
                }
            }

            if (peticion.InfoLegal != null)
            {
                await _registroLegalService.EliminarPorIdFichaAsync(ficha.IdFicha);
                foreach (var item in peticion.InfoLegal)
                {
                    item.IdFicha = ficha.IdFicha;
                    await _registroLegalService.CrearAsync(item);
                }
            }

            if (peticion.InfoComplementario != null)
            {
                var tipoMantenimiento = await _tipoMantenimientoRepository.BuscarPorCodigoAsync(TipoMantenimientoEnum.PredioCatastralNuevo);

                var idInformacionComplementaria = default(int);
                if (ficha.InfoComplementarios.Count > 0)
                {
                    idInformacionComplementaria = ficha.InfoComplementarios.FirstOrDefault().IdInfoComplementario;
                }

                peticion.InfoComplementario.TipoMantenimiento = new TipoMantenimientoDto
                {
                    IdTipoMantenimiento = tipoMantenimiento.IdTipoMantenimiento
                };

                peticion.InfoComplementario.IdInfoComplementario = idInformacionComplementaria;
                peticion.InfoComplementario.IdFicha = ficha.IdFicha;

                var infoComplementaria = await _infoComplementarioService.CrearOActualizarAsync(peticion.InfoComplementario);
                //if (!infoComplementaria.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, infoComplementaria.Mensajes);
            }

            if (peticion.DeclaranteInfo != null && (peticion.DeclaranteInfo?.IdPersona != null || peticion.DeclaranteInfo?.IdPersona != 0))
            {
                var idDeclarante = default(int);
                if (ficha.Declarantes.Count > 0) idDeclarante = ficha.Declarantes.FirstOrDefault().IdDeclarante;

                peticion.DeclaranteInfo.IdDeclarante = idDeclarante;
                peticion.DeclaranteInfo.IdFicha = ficha.IdFicha;
                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            if (peticion.SupervisorInfo != null && peticion.SupervisorInfo?.IdPersona != 0)
            {
                var idSupervisor = default(int);
                if (ficha.Supervisores.Count > 0) idSupervisor = ficha.Supervisores.FirstOrDefault().IdSupervisor;

                peticion.SupervisorInfo.IdSupervisor = idSupervisor;
                peticion.SupervisorInfo.IdFicha = ficha.IdFicha;
                var supervisorRespuesta = await _supervisorService.GuardarPersonaSupervisorAsync(peticion.SupervisorInfo);
                //if (!supervisorRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, supervisorRespuesta.Mensajes);
            }

            if (peticion.TecnicoInfo != null && peticion.TecnicoInfo?.IdPersona != 0)
            {
                var idTecnicoCatastral = default(int);
                if (ficha.TecnicoCatastrales.Count > 0) idTecnicoCatastral = ficha.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;

                peticion.TecnicoInfo.IdTecnico = idTecnicoCatastral;
                peticion.TecnicoInfo.IdFicha = ficha.IdFicha;
                var tecnicoRespuesta = await _tecnicoCatastralService.GuardarPersonaTecnicoCatastralAsync(peticion.TecnicoInfo);
                //if (!tecnicoRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tecnicoRespuesta.Mensajes);
            }

            if (peticion.AreaTerrenoInvalid != null)
            {
                await _areaTerrenoInvalidService.CreateAreaTerreno(peticion.AreaTerrenoInvalid);
            }

            var fichaIndividualUpdate = await FichaIndividualPorIdAsync(peticion.idFichaIndividual);

            if (fichaIndividualUpdate == null) throw new Exception("No existe ficha individual");

            fichaIndividualUpdate.Ficha.IdFichaPadre = ficha.IdFicha;
            await CrearOActualizarFichaAsync(fichaIndividualUpdate.Ficha, fichaIndividualUpdate.Ficha.Estado);

            return ficha.IdFicha;
        }
        public async Task<BienComunDto> FichaBienComunPorIdAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindBienComunByIdAsync(idFicha);

            if (ficha == null) throw new Exception("No se encontró la ficha bien comun");

            var dto = _mapper.Map<BienComunDto>(ficha);

            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(ficha.IdFicha, ficha.Estado);
            if (fichasAsociadas != null)
            {
                dto.CantidadUnidadesAsociadas = fichasAsociadas.Count();
                fichasAsociadas.ForEach(f =>
                {

                    if (f.IdTipoFicha == (int)TipoFichaEnum.Individual)
                    {
                        dto.idFichaIndividual = f.IdFicha;
                    }
                });
            }

            return dto;
        }
        public async Task<BienComunDto> FichaBienComunPorTBLCodigodAsync(BienCommunPeticionDto peticion)
        {
            var tblCod = new TblCodigo()
            {
                CodDistrito = peticion.CodDistrito,
                CodSector = peticion.CodSector,
                CodManzana = peticion.CodManzana,
                CodLote = peticion.CodLote,
                CodEdif = peticion.CodEdif,
                CodEnt = peticion.CodEnt,
                CodPiso = peticion.CodPiso,
                CodUnid = peticion.CodUnid,
            };
            var unidadCatastral = await _unidadCatastralRepository.ObtenerPorCodigoCatastralBienComunAsync(tblCod);

            var unidadCatrastalBienComun = new UnidadCatastral();
            unidadCatastral.ForEach(u =>
            {
                if (u.Fichas.Any(e => e.IdTipoFicha == 3 && e.TipoBienComun == peticion.tipoFichaBienComun))
                {
                    unidadCatrastalBienComun = u;
                };

            });


            var ficha = await _fichaRepository.ObtenerPorIdUnidadAnioFichaIdTipoAsync(unidadCatrastalBienComun.IdUnidadCatastral, EstadoFicha.Dinamico, peticion.Anio, TipoFichaEnum.BienesComunes);

            if (ficha == null) throw new Exception("No se encontro la ficha bien comun");

            var dto = _mapper.Map<BienComunDto>(ficha);

            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(ficha.IdFicha, ficha.Estado);
            if (fichasAsociadas != null)
            {
                fichasAsociadas.ForEach(f =>
                {
                    if (f.IdTipoFicha == (int)TipoFichaEnum.Individual)
                    {
                        dto.idFichaIndividual = f.IdFicha;
                    }
                });
            }

            return dto;
        }
        //Economica
        public async Task<List<ActividadEconomicaDto>> FindFichasActividadesEconomicasByIdAsync(List<int> idFicha)
        {
            List<ActividadEconomicaDto> dtos = new List<ActividadEconomicaDto>();
            foreach (var item in idFicha)
            {
                var ficha = await _fichaRepository.FindFichaActividadEconomicaByIdAsync(item);
                var dto = _mapper.Map<ActividadEconomicaDto>(ficha);

                dtos.Add(dto);

            }

            return dtos;
        }
        public async Task<ActividadEconomicaDto> FindFichaActividadEconomicaByIdAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindFichaActividadEconomicaByIdAsync(idFicha);

            var dto = _mapper.Map<ActividadEconomicaDto>(ficha);

            return dto;
        }
        public async Task<List<int>> ListaIdsFichasEconomicasPorIdFichaIndividual(int idFicha)
        {
            var fichasAsociadas = await _fichaRepository.BuscarPorIdFichaPadreYEstadoFichaAsync(idFicha, (int)EstadoFicha.Dinamico);
            List<int> listaIds = new List<int>();
            if (fichasAsociadas != null)
            {
                fichasAsociadas.ForEach(f =>
                {
                    if (f.IdTipoFicha == (int)TipoFichaEnum.ActividadEconomica)
                    {
                        listaIds.Add(f.IdFicha);
                    }
                });

            }

            return listaIds;
        }
        public async Task<int> GuardarFichaActividadEconomica2Async(ActividadEconomicaDto peticion)
        {
            

            var fichaPadre = await _fichaRepository.Find(peticion.Ficha?.IdFichaPadre ?? 0);
          //  if (fichaPadre == null) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "Primero registre una ficha individual.");

            peticion.Ficha.IdTipoFicha = (int)TipoFichaEnum.ActividadEconomica;
            peticion.Ficha.IdUnidadCatastral = fichaPadre.IdUnidadCatastral;

            var fichaRespuesta = await CrearOActualizarFichaAsync(peticion.Ficha,2);
           // if (!fichaRespuesta.Completado)
           // {
           //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, fichaRespuesta.Mensajes);
           // }

            var infoFicha = await _fichaRepository.Find(fichaRespuesta.IdFicha);

            var idTblCodigo = default(int);
            if (peticion.CodigoCatastral != null)
            {
                peticion.CodigoCatastral.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigo = await _tblCodigoService.CrearOActualizarCodigoCatastralAsync(peticion.CodigoCatastral);
                //if (!tblCodigo.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigo.Mensajes);

                idTblCodigo = tblCodigo.IdTblCodigo;
            }

            if (peticion.CodigoCatastralRef != null)
            {
                peticion.CodigoCatastralRef.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigoRef = await _tblCodigoService.CrearOActualizarCodigoCatastralReferencialAsync(peticion.CodigoCatastralRef);
                //if (!tblCodigoRef.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigoRef.Mensajes);
            }

            var idConductor = default(int);
            //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.Conductor).LoadAsync();

            var idPersonaRepresentate = new int?();
            if (peticion.Representante != null && peticion.Representante?.IdPersona != 0)
            {
                idPersonaRepresentate = peticion.Representante.IdPersona;
            }

            if (infoFicha.Conductores != null && infoFicha.Conductores.Count > 0)
            {
                idConductor = infoFicha.Conductores.FirstOrDefault().IdConductor;
            }

            if (peticion.ConductorPersona != null)
            {
                peticion.ConductorPersona.IdConductor = idConductor;
                peticion.ConductorPersona.IdFicha = fichaRespuesta.IdFicha;
                peticion.ConductorPersona.IdRepresentanteLegal = idPersonaRepresentate;
                var conductorPersona = await _conductorService.GuardarPersonaConductorAsync(peticion.ConductorPersona);
                if (conductorPersona != 0)
                {
                    var idPersona = peticion.ConductorPersona?.IdPersona != 0 ? peticion.ConductorPersona.IdPersona : 0;
                    var infoDomicilioCondutor = await _domicilioRepository.BusquedaSimplePorIdPersonaAsync((int)idPersona);
                    var idEdificacionCondutor = default(int);
                    var idDomicilioConductor = default(int);
                    if (infoDomicilioCondutor != null)
                    {
                        idDomicilioConductor = infoDomicilioCondutor.IdDomicilio;
                        if(infoDomicilioCondutor.IdEdificacion != null)
                        {
                            idEdificacionCondutor = (int)infoDomicilioCondutor.IdEdificacion;
                        }
                        else
                        {
                            idEdificacionCondutor = 0;
                        }
                        
                    }

                    if (peticion.DomicilioConductor != null)
                    {
                        if (peticion.DomicilioConductor.Edificacion != null)
                        {
                            peticion.DomicilioConductor.Edificacion.IdEdificacion = idEdificacionCondutor;
                            var edificacionDomicilio = await _edificacionService.CrearOActualizarAsync(peticion.DomicilioConductor.Edificacion);
                           // if (!edificacionDomicilio.Completado)
                           // {
                          //      return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, edificacionDomicilio.Mensajes);
                          //  }

                            peticion.DomicilioConductor.IdDomicilioConductor = idDomicilioConductor;
                            peticion.DomicilioConductor.Edificacion.IdEdificacion = edificacionDomicilio.IdEdificacion;
                            peticion.DomicilioConductor.IdPersona = idPersona;

                            var domicilio = await _domicilioService.CrearOActualizarDomicilioConductorAsync(peticion.DomicilioConductor);
                           // if (!domicilio.Completado)
                           // {
                           //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, domicilio.Mensajes);
                            //}
                        }
                    }
                }
            }

            if (peticion.AreaActEconomica != null)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.AreaActividadEconomica).LoadAsync();
                var idAreaActividadEconomica = default(int);
                if (infoFicha.AreaActividadEconomicas != null && infoFicha.AreaActividadEconomicas.Count > 0)
                {
                    idAreaActividadEconomica = infoFicha.AreaActividadEconomicas.FirstOrDefault().IdAreaActividadEconomica;
                }

                peticion.AreaActEconomica.IdAreaActividadEconomica = idAreaActividadEconomica;
                peticion.AreaActEconomica.IdFicha = fichaRespuesta.IdFicha;
                var areaActividadEconomica = await _areaActividadEconomicaService.CrearOActualizarAsync(peticion.AreaActEconomica);
                //if (!areaActividadEconomica.Completado)
               // {
               //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, areaActividadEconomica.Mensajes);
               // }
            }

            await _autorizacionMunicipalService.EliminarPorIdFichaAsync(fichaRespuesta.IdFicha);
            if (peticion.AutorizacionMunicipal != null)
            {
                foreach (var item in peticion.AutorizacionMunicipal)
                {
                    item.IdFicha = fichaRespuesta.IdFicha;
                    var autorizacionMunicipal = await _autorizacionMunicipalService.CrearAsync(item);
                  //  if (!autorizacionMunicipal.Completado)
                  //  {
                   //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, autorizacionMunicipal.Mensajes);
                   // }
                }
            }

            await _autorizacionAnuncioService.EliminarPorIdFichaAsync(fichaRespuesta.IdFicha);
            if (peticion.AutorizacionAnuncio != null)
            {
                foreach (var item in peticion.AutorizacionAnuncio)
                {
                    item.IdFicha = fichaRespuesta.IdFicha;
                    var autorizacionAnuncio = await _autorizacionAnuncioService.CrearAsync(item);
                   // if (!autorizacionAnuncio.Completado)
                   // {
                   //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, autorizacionAnuncio.Mensajes);
                   // }
                }
            }

            var tipoMantenimiento = await _tipoMantenimientoRepository.BuscarPorCodigoAsync(TipoMantenimientoEnum.PredioCatastralNuevo);

            if (peticion.InfoComplementaria != null)
            {
               // await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.InformacionComplementaria).LoadAsync();
                var idInformacionComplementaria = default(int);
                if (infoFicha.InfoComplementarios.Count > 0)
                {
                    idInformacionComplementaria = infoFicha.InfoComplementarios.FirstOrDefault().IdInfoComplementario;
                }
                if(peticion.InfoComplementaria.TipoMantenimiento != null) peticion.InfoComplementaria.TipoMantenimiento.IdTipoMantenimiento = tipoMantenimiento.IdTipoMantenimiento;
                peticion.InfoComplementaria.IdInfoComplementario = idInformacionComplementaria;
                peticion.InfoComplementaria.IdFicha = fichaRespuesta.IdFicha;
                var infoComplementaria = await _infoComplementarioService.CrearOActualizarAsync(peticion.InfoComplementaria);
               // if (!infoComplementaria.Completado)
               // {
               //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, infoComplementaria.Mensajes);
               // }
            }

            if ((peticion.DeclaranteInfo != null && peticion.DeclaranteInfo?.IdPersona != 0) || peticion.DeclaranteInfo?.CondicionPer != null)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.Declarante).LoadAsync();
                var idDeclarante = default(int);
                if (infoFicha.Declarantes.Count > 0) idDeclarante = infoFicha.Declarantes.FirstOrDefault().IdDeclarante;

                peticion.DeclaranteInfo.IdDeclarante = idDeclarante;
                peticion.DeclaranteInfo.IdFicha = infoFicha.IdFicha;
                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }

            if  (peticion.SupervisorInfo != null && peticion.SupervisorInfo?.IdPersona != 0)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.Supervisor).LoadAsync();
                var idSupervisor = default(int);
                if (infoFicha.Supervisores.Count > 0) idSupervisor = infoFicha.Supervisores.FirstOrDefault().IdSupervisor;

                peticion.SupervisorInfo.IdSupervisor = idSupervisor;
                peticion.SupervisorInfo.IdFicha = infoFicha.IdFicha;
                var supervisorRespuesta = await _supervisorService.GuardarPersonaSupervisorAsync(peticion.SupervisorInfo);
                //if (!supervisorRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, supervisorRespuesta.Mensajes);
            }


            if  (peticion.TecnicoInfo != null && peticion.TecnicoInfo?.IdPersona != 0)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.TecnicoCatastral).LoadAsync();
                var idTecnicoCatastral = default(int);
                if (infoFicha.TecnicoCatastrales.Count > 0) idTecnicoCatastral = infoFicha.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;

                peticion.TecnicoInfo.IdTecnico = idTecnicoCatastral;
                peticion.TecnicoInfo.IdFicha = infoFicha.IdFicha;
                var tecnicoRespuesta = await _tecnicoCatastralService.GuardarPersonaTecnicoCatastralAsync(peticion.TecnicoInfo);
               // if (!tecnicoRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tecnicoRespuesta.Mensajes);
            }

            return infoFicha.IdFicha;
        }
        //Cultural
        public async Task<BienCulturalDto> FindFichaBienCulturalByIdAsync(int idFicha)
        {
            var ficha = await _fichaRepository.FindFichaBienCulturalByIdAsync(idFicha);

            var dto = _mapper.Map<BienCulturalDto>(ficha);

            return dto;
        }

        public async Task<int> GuardarFichaBienCultural2Async(BienCulturalDto peticion)
        {
            //var operacionValidacion = ValidacionUtilitario.ValidarModelo<RespuestaSimpleDto<string>>(peticion);

            //if (!operacionValidacion.Completado) return operacionValidacion;

            var fichaPadre = await _fichaRepository.Find(peticion.Ficha?.IdFichaPadre ?? 0);
            //if (fichaPadre == null) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, "Primero registre una ficha individuala");



            peticion.Ficha.IdTipoFicha = (int)TipoFichaEnum.BienesCulturales;
            peticion.Ficha.IdUnidadCatastral = fichaPadre.IdUnidadCatastral;
            peticion.Ficha.Estado = fichaPadre.Estado;
            var ficha = await CrearOActualizarFichaAsync(peticion.Ficha,1);
            //if (!ficha.Completado)
            //{
            //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, ficha.Mensajes);
           // }

            var infoFicha = await _fichaRepository.Find(ficha.IdFicha);

            if (peticion.CodigoCatastral != null)
            {
                peticion.CodigoCatastral.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigo = await _tblCodigoService.CrearOActualizarCodigoCatastralAsync(peticion.CodigoCatastral);
               // if (!tblCodigo.Completado)
               // {
               //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigo.Mensajes);
               // }
            }

            if (peticion.CodigoCatastralRef != null)
            {
                peticion.CodigoCatastralRef.IdUnidadCatastral = peticion.Ficha.IdUnidadCatastral;
                var tblCodigoRef = await _tblCodigoService.CrearOActualizarCodigoCatastralReferencialAsync(peticion.CodigoCatastralRef);
               // if (!tblCodigoRef.Completado)
               // {
               //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tblCodigoRef.Mensajes);
               // }
            }

            //await _fichaRepository.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.FichaBienCultural).Query().Include(e => e.MonumentoPreinspanico).Include(e => e.MonumentoColonial).LoadAsync();

            var idFichaBienCultural = default(int);
            var idMonumentoPreinspanico = default(int);
            var idMonumentoColonial = default(int);

            if (infoFicha.FichaBienCulturales != null && infoFicha.FichaBienCulturales.Count > 0)
            {
                idFichaBienCultural = infoFicha.FichaBienCulturales.FirstOrDefault().IdFichaBienCultural;
                if (infoFicha.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.Count > 0)
                {
                    idMonumentoPreinspanico = infoFicha.FichaBienCulturales.FirstOrDefault().MonumentoPreinspanico.FirstOrDefault().IdMonumentoPrehispanico;
                }
                if (infoFicha.FichaBienCulturales.FirstOrDefault().MonumentoColonial.Count > 0)
                {
                    idMonumentoColonial = infoFicha.FichaBienCulturales.FirstOrDefault().MonumentoColonial.FirstOrDefault().IdMonumentoColonial;
                }
            }

            if (peticion.DatoAdicinalFicha != null)
            {
                peticion.DatoAdicinalFicha.IdFichaBienCultural = idFichaBienCultural;
                peticion.DatoAdicinalFicha.IdFicha = ficha.IdFicha;
                var fichaBienCultural = await _fichaBienCulturalService.CrearOActualizarAsync(peticion.DatoAdicinalFicha);
                if (fichaBienCultural != 0)
                {
                    if (peticion.MonumentoPrehispanico != null)
                    {
                        peticion.MonumentoPrehispanico.IdMonumentoPrehispanico = idMonumentoPreinspanico;
                        peticion.MonumentoPrehispanico.IdFichaBienCultural = fichaBienCultural;
                        var monumentoPreinspanico = await _monumentoPrehispanicoService.CrearOActualizarAsync(peticion.MonumentoPrehispanico);
                        if (monumentoPreinspanico != 0)
                        {
                            if (peticion.RegistroPrediosMonumentoPre != null)
                            {
                                //await _sunarpServicio.EliminarPorIdFichaAsync(ficha.Resultado.Id);
                                await _sunarpService.EliminarPorIdFichaAsync(ficha.IdFicha);
                                foreach (var item in peticion.RegistroPrediosMonumentoPre)
                                {
                                    item.IdFicha = ficha.IdFicha;
                                    item.IdMonumentoPre = monumentoPreinspanico;
                                    //var sunarp = await _sunarpServicio.CrearAsync(item);
                                    var sunarp = await _sunarpService.CrearAsync(item);
                                   // if (!sunarp.Completado)
                                   // {
                                   //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, sunarp.Mensajes);
                                   // }
                                }
                            }

                            if (peticion.NormaInteresMonPreinspanico != null)
                            {
                                await _normaIntMonPreinsService.EliminarPorIdMonumentoPreinspanicoAsync((int)monumentoPreinspanico);
                                foreach (var item in peticion.NormaInteresMonPreinspanico)
                                {
                                    item.IdMonumentoPre = monumentoPreinspanico;
                                    //var normaIntMonPreins = await _normaIntMonPreinsServicio.CrearAsync(item);
                                    var normaIntMonPreins = await _normaIntMonPreinsService.CrearOActualizarAsync(item);
                                   // if (!normaIntMonPreins.Completado)
                                   // {
                                        //return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, normaIntMonPreins.Mensajes);
                                   // }
                                }
                            }
                        }
                    }
                    if (peticion.InfoMonumentoColonial != null)
                    {
                        peticion.InfoMonumentoColonial.IdMonumentoColonial = idMonumentoColonial;
                        peticion.InfoMonumentoColonial.IdFichaBienCultural = fichaBienCultural;
                        var monumentoColonial = await _monumentoColonialService.CrearOActualizarAsync(peticion.InfoMonumentoColonial);
                        if (monumentoColonial!= 0)
                        {
                            if (peticion.RegistroPrediosMonumentoColonial != null)
                            {
                                //await _sunarpServicio.EliminarPorIdFichaAsync(ficha.Resultado.Id);
                                await _sunarpService.EliminarPorIdFichaAsync(ficha.IdFicha);
                                foreach (var item in peticion.RegistroPrediosMonumentoColonial)
                                {
                                    item.IdFicha = ficha.IdFicha;
                                    item.IdMonumentoColonial = monumentoColonial;
                                    //var sunarp = await _sunarpServicio.CrearAsync(item);
                                    var sunarp = await _sunarpService.CrearAsync(item);
                                   // if (!sunarp.Completado)
                                   // {
                                   //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, sunarp.Mensajes);
                                   // }
                                }
                            }

                            if (peticion.NormaInteresMonColonial != null)
                            {
                                //await _normaIntMonPreinsServicio.EliminarPorIdMonumentoPreinspanicoAsync(monumentoColonial.Resultado.Id);
                                await _normaIntMonColonialService.EliminarPorIdMonumentoColonialAsync((int)monumentoColonial);
                                foreach (var item in peticion.NormaInteresMonColonial)
                                {
                                    item.IdMonumentoColonial = monumentoColonial;
                                    //var normaIntMonColonial = await _normaIntMonColonialServicio.CrearAsync(item);
                                    var normaIntMonColonial = await _normaIntMonColonialService.CrearOActualizarAsync(item);
                                   // if (!normaIntMonColonial.Completado)
                                    //{
                                        //return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, normaIntMonPreins.Mensajes);
                                   // }
                                }
                            }
                        }
                    }
                }
            }

           // await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.TitularCatastral).LoadAsync();

            var idTitularCatastral = default(int);
            var idCaracteristicaTitular = default(int);

            if (infoFicha.TitularCatastral != null && infoFicha.TitularCatastral.Count > 0)
            {
                idTitularCatastral = infoFicha.TitularCatastral.FirstOrDefault().IdTitularCatastral;
                if (infoFicha.TitularCatastral.FirstOrDefault().IdCaracteristicaTitularidad != null)
                {
                    idCaracteristicaTitular = (int)infoFicha.TitularCatastral.FirstOrDefault().IdCaracteristicaTitularidad;
                }
            }

            if (peticion.Titular != null)
            {
                peticion.Titular.IdTitularCatastral = idTitularCatastral;
                peticion.Titular.IdFicha = ficha.IdFicha;
                //peticion.Titular.IdCaracteristicaTitularidad = caracteristicaTitularidad.Resultado.Id;

                var titular = await _titularCatastralService.GuardarPersonaTitularAsync(peticion.Titular);
            }

            await _litiganteService.EliminarPorIdFichaAsync(ficha.IdFicha);

            if (peticion.NaturalLitigante != null)
            {
                foreach (var item in peticion.NaturalLitigante)
                {
                    item.IdFicha = ficha.IdFicha;
                    var litigante = await _litiganteService.GuardarPersonaLitiganteAsync(item);
                    //if (!litigante.Completado)
                   // {
                   //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, litigante.Mensajes);
                   // }
                }

            }

            if (peticion.ConyugesLitigante != null)
            {
                var litigantes = await _litiganteRepository.ListarPorIdFichaAsync(ficha.IdFicha);
                if (litigantes != null)
                {
                    if (litigantes.Count > 0)
                    {
                        foreach (var item in peticion.ConyugesLitigante)
                        {
                            item.IdLitigante = litigantes.FirstOrDefault().IdLitigante;
                            var conyugueLitigante = await _dependienteService.GuardarConyugeLitiganteAsync(item);
                            // if (!conyugueLitigante.Completado)
                            //{
                            //     return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, conyugueLitigante.Mensajes);
                            // }
                        }
                    }
                }

            }

            if (peticion.JuridicoLitigante != null)
            {
                foreach (var item in peticion.JuridicoLitigante)
                {
                    item.IdFicha = ficha.IdFicha;
                    var litiganteJuridico = await _litiganteService.GuardarJuridicoaLitiganteAsync(item);
                   // if (!litiganteJuridico.Completado)
                   // {
                        //return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, litiganteJuridico.Mensajes);
                   // }
                }
            }

            if (peticion.InfoComplementaria != null)
            {
               // await _fichaRepository.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.InformacionComplementaria).LoadAsync();
                var idInformacionComplementaria = default(int);
                if (infoFicha.InfoComplementarios.Count > 0)
                {
                    idInformacionComplementaria = infoFicha.InfoComplementarios.FirstOrDefault().IdInfoComplementario;
                }

                peticion.InfoComplementaria.IdInfoComplementario = idInformacionComplementaria;
                peticion.InfoComplementaria.IdFicha = ficha.IdFicha;
                var infoComplementaria = await _infoComplementarioService.CrearOActualizarAsync(peticion.InfoComplementaria);
               // if (!infoComplementaria.Completado)
               // {
                //    return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, infoComplementaria.Mensajes);
               // }
            }

            if ((peticion.DeclaranteInfo?.IdPersona != null && peticion.DeclaranteInfo?.IdPersona != 0) || peticion.DeclaranteInfo?.CondicionPer != null)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.Declarante).LoadAsync();
                var idDeclarante = default(int);
                if (infoFicha.Declarantes.Count > 0) idDeclarante = infoFicha.Declarantes.FirstOrDefault().IdDeclarante;

                peticion.DeclaranteInfo.IdDeclarante = idDeclarante;
                peticion.DeclaranteInfo.IdFicha = infoFicha.IdFicha;
                var declaranteRespuesta = await _declaranteService.GuardarDeclaranteAsync(peticion.DeclaranteInfo);
                //if (!declaranteRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, declaranteRespuesta.Mensajes);
            }


            if (peticion.SupervisorInfo?.IdPersona != 0 && peticion.SupervisorInfo?.IdPersona != null)
            {
                //await _fichaRepositorio.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.Supervisor).LoadAsync();
                var idSupervisor = default(int);
                if (infoFicha.Supervisores.Count > 0) idSupervisor = infoFicha.Supervisores.FirstOrDefault().IdSupervisor;

                peticion.SupervisorInfo.IdSupervisor = idSupervisor;
                peticion.SupervisorInfo.IdFicha = infoFicha.IdFicha;
                var supervisorRespuesta = await _supervisorService.GuardarPersonaSupervisorAsync(peticion.SupervisorInfo);
                //if (!supervisorRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, supervisorRespuesta.Mensajes);
            }


            if (peticion.TecnicoInfo?.IdPersona != 0 && peticion.TecnicoInfo?.IdPersona != null)
            {
                //await _fichaRepository.UnidadDeTrabajo.Entry(infoFicha).Collection(e => e.TecnicoCatastral).LoadAsync();
                var idTecnicoCatastral = default(int);
                if (infoFicha.TecnicoCatastrales.Count > 0) idTecnicoCatastral = infoFicha.TecnicoCatastrales.FirstOrDefault().IdTecnicoCatastral;

                peticion.TecnicoInfo.IdTecnico = idTecnicoCatastral;
                peticion.TecnicoInfo.IdFicha = infoFicha.IdFicha;
                var tecnicoRespuesta = await _tecnicoCatastralService.GuardarPersonaTecnicoCatastralAsync(peticion.TecnicoInfo);
                //if (!tecnicoRespuesta.Completado) return new OperacionDto<RespuestaSimpleDto<string>>(CodigosOperacionDto.Invalido, tecnicoRespuesta.Mensajes);
            }

            return infoFicha.IdFicha;
        }

        public async Task<ResponsePagination<FichaBusquedaDto>> SelectPaginatedSearch(RequestPagination<FichaBusquedaDto> dto)
        {
            var entity = _mapper.Map<RequestPagination<FichaBusqueda>>(dto);
            var response = await _fichaRepository.SelectPaginatedSearch(entity);
            return _mapper.Map<ResponsePagination<FichaBusquedaDto>>(response);
        }
    }
}
