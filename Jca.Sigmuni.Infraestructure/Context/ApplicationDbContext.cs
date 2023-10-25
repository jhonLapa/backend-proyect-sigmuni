using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.ModelMaps;
using Jca.Sigmuni.Domain.Vias;
using Jca.Sigmuni.Domain.Zonificaciones;
using Jca.Sigmuni.Infraestructure.ModelMaps.Admins;
using Jca.Sigmuni.Infraestructure.ModelMaps.CompendioNormas;
using Jca.Sigmuni.Infraestructure.ModelMaps.General;
using Jca.Sigmuni.Infraestructure.ModelMaps.Habilitaciones;
using Jca.Sigmuni.Infraestructure.ModelMaps.PadronNumeraciones.Numeraciones;
using Jca.Sigmuni.Infraestructure.ModelMaps.ProcesosTecnicos;
using Jca.Sigmuni.Infraestructure.ModelMaps.TramiteDocumentario;
using Jca.Sigmuni.Infraestructure.ModelMaps.Vias;
using Jca.Sigmuni.Infraestructure.ModelMaps.Zonificaciones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Jca.Sigmuni.Infraestructure.ModelMaps.Incidencias;
using Jca.Sigmuni.Domain.Incidencias;
using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Infraestructure.ModelMaps.ArchivoDocumentario;
using Jca.Sigmuni.Domain.Jurisdiccion;
using Jca.Sigmuni.Infraestructure.ModelMaps.Jurisdiccion;

namespace Jca.Sigmuni.Infraestructure.Context
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DBConnection"));
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        #region adminds
        public DbSet<Role> Roles { get; set; }
        public DbSet<Usuario> Users { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<AreaCargo> AreaCargos { get; set; }
        #endregion

        #region General
        //General
        public DbSet<TipoPersona> TipoPersonas { get; set; }
        public DbSet<TecnicoCatastral> TecnicoCatastrales { get; set; } 
        public DbSet<Supervisor> Supervisores { get; set; }
        public DbSet<IntervencionInmueble> IntervencionInmuebles { get; set; }
        public DbSet<EstadoAcabado> EstadoAcabados { get; set; }
        public DbSet<FiliacionEstilistica> FiliacionEstilisticas { get; set; }
        public DbSet<ElementoArquitectonico> ElementoArquitectonicos { get; set; }
        public DbSet<TiempoConstruccion> TiempoConstrucciones { get; set; }
        public DbSet<Observacion> Observaciones { get; set; }
        public DbSet<IntervencionConservacion> IntervencionConservaciones { get; set; }
        public DbSet<AfectacionAntropica> AfectacionAntropicas { get; set; }
        public DbSet<AfectacionNatural> AfectacionNaturales { get; set; }
        public DbSet<TipoMaterial> TipoMateriales { get; set; }
        public DbSet<TipoArquitectura> TipoArquitecturas { get; set; }
        public DbSet<CategoriaInmueble> CategoriaInmuebles { get; set; }
        public DbSet<FiliacionCronologica> FiliacionCronologicas { get; set; }
        public DbSet<DocumentoIdentidad> DocumentoIdentidades { get; set; }
        public DbSet<Perfil> Perfils { get; set; }
        public DbSet<Ubigeo> Ubigeos { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<Manzana> Manzanas { get; set; }
        public DbSet<Sector> Sectores { get; set; }
        public DbSet<InfoContacto> InfoContactos { get; set; }
        public DbSet<RepresentanteLegal> RepresentantesLegales { get; set; }
        public DbSet<EstadoCivil> EstadoCivils { get; set; }
        public DbSet<Domicilio> Domicilios { get; set; }
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Motivo> Motivos { get; set; }

        public DbSet<UnidadCatastral> UnidadesCatastrales { get; set; }
        public DbSet<TblCodigo> TblCodigos { get; set; }
        public DbSet<CondicionEspecialTitular> CondicionEspecialTitulares { get; set; }
        public DbSet<TipoExoneracion> TipoExoneraciones { get; set; }
        public DbSet<ExoneracionTitular> ExoneracionTitulares { get; set; }
        public DbSet<TipoAsignacion> TipoAsignaciones { get; set; }
        public DbSet<Dependiente> Dependientes { get; set; }
        public DbSet<AreaTratamiento> AreaTratamientos { get; set; }

        public DbSet<Uit> Uits { get; set; }

        #endregion

        #region Procesos Tecnicos
        public DbSet<GiroAutorizado> GirosAutorizados { get; set; }
        public DbSet<Arancel> Aranceles { get; set; }
        public DbSet<Antiguedad> Antiguedades { get; set; }
        public DbSet<ControlFicha> ControlFichas { get; set; }
        public DbSet<Depreciacion> Depreciaciones { get; set; }
        public DbSet<TipoDocumentoFicha> TipoDocumentoFichas { get; set; }
        public DbSet<CondicionNumeracion> CondicionNumeraciones { get; set; }
        public DbSet<CategoriaConstruccion> CategoriaConstrucciones { get; set; }
        public DbSet<TipoInterior> TipoInteriores { get; set; }
        public DbSet<NormaIntMonColonial> NormaIntMonColoniales { get; set; }
        public DbSet<NormaIntMonPrehi> NormaIntMonPrehis { get; set; }
        public DbSet<MonumentoColonial> MonumentoColoniales { get; set; }
        public DbSet<FichaBienCultural> FichasBienesCulturales { get; set; }
        public DbSet<MonumentoPrehispanico> MonumentoPrehispanicos { get; set; }
        public DbSet<ActividadVerificada> ActividadesVerificadas { get; set; }
        public DbSet<CondicionTitular> CondicionesTitulares { get; set; }
        public DbSet<CondicionEspecialPredio> condicionEspecialPredios { get; set; }
        public DbSet<ClasificacionPredio> ClasificacionPredios { get; set; }
        public DbSet<PredioCatastralEn> PredioCatastralEns { get; set; }
        public DbSet<PredioCatastralAn> PredioCatastralAns { get; set; }
        public DbSet<UsoPredio> UsoPredios { get; set; }
        public DbSet<CondicionAnuncio> CondicionAnuncios { get; set; }
        public DbSet<TipoAnuncio> TipoAnuncios { get; set; }
        public DbSet<CondicionConductor> CondicionConductores { get; set; }
        public DbSet<Ecc> Eccs { get; set; }
        public DbSet<Ecs> Ecss { get; set; }
        public DbSet<EdificacionIndustrial> EdificacionIndustriales { get; set; }
        public DbSet<Mep> Meps { get; set; }
        public DbSet<Uca> Ucas { get; set; }
        public DbSet<EstadoLlenado> EstadoLlenados { get; set; }
        public DbSet<TipoInspeccion> TipoInspecciones { get; set; }
        public DbSet<TipoMantenimiento> TipoMantenimientos { get; set; }
        public DbSet<TipoServicioBasico> TipoServicioBasicos { get; set; }
        public DbSet<TipoEvaluacion> TipoEvaluaciones { get; set; }
        public DbSet<TipoPartidaRegistral> TipoPartidaRegistrales { get; set; }
        public DbSet<TipoTituloInscrito> TipoTituloInscritos { get; set; }
        public DbSet<TipoLitigante> TipoLitigantes { get; set; }
        public DbSet<TipoDeclaratoria> TipoDeclaratorias { get; set; }
        public DbSet<FormaAdquisicion> FormaAdquisiciones { get; set; }
        public DbSet<TipoDocNotarial> TipoDocNotariales { get; set; }
        public DbSet<TipoDocumentoObra> TipoDocumentoObras { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<TipoFicha> TipoFichas { get; set; }
        public DbSet<CondicionPer> CondicionPers { get; set; }
        public DbSet<Declarante> Declarantes { get; set; }
        public DbSet<InfoComplementario> InfoComplementarios { get; set; }
        public DbSet<CaracteristicaTitularidad> CaracteristicaTitularidades { get; set; }
        public DbSet<ExoneracionPredio> ExoneracionPredios { get; set; }
        public DbSet<DescripcionPredio> DescripcionPredios { get; set; }
        public DbSet<EvaluacionPredio> EvaluacionPredios { get; set; }
        public DbSet<ServicioBasico> ServicioBasicos { get; set; }
        public DbSet<AutorizacionAnuncio> AutorizacionAnuncios { get; set; }
        public DbSet<AreaActividadEconomica> AreaActividadEconomicas { get; set; }
        public DbSet<Construccion> Construcciones { get; set; }
        public DbSet<FichaIndividual> FichaIndividuales { get; set; }
        public DbSet<UnidadMedida> UnidadMedidas { get; set; }
        public DbSet<TipoOtraInstalacion> TipoOtraInstalaciones { get; set; }
        public DbSet<OtraInstalacion> OtraInstalaciones { get; set; }
        public DbSet<CategoriaOrganizacion> CategoriaOrganizaciones { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<FichaDocumento> FichaDocumentos { get; set; }
        public DbSet<Sunarp> Sunarps { get; set; }
        public DbSet<RegistroLegal> RegistroLegales { get; set; }
        public DbSet<Litigante> Litigantes { get; set; }
        public DbSet<DocumentoObra> DocumentoObras { get; set; }
        public DbSet<TipoResolucion> TipoResoluciones { get; set; }
        public DbSet<Resolucion> Resoluciones { get; set; }
        public DbSet<AutorizacionMunicipal> AutorizacionMunicipales { get; set; }
        public DbSet<TipoEdificacion> TipoEdificaciones { get; set; }
        public DbSet<TipoAgrupacion> TipoAgrupaciones { get; set; }
        public DbSet<Edificacion> Edificaciones { get; set; }
        public DbSet<UbicacionPredio> UbicacionPredios { get; set; }
        public DbSet<TipoPuerta> TipoPuertas { get; set; }
        public DbSet<Puerta> ViaPuertas { get; set; }
        public DbSet<TitularCatastral> TitularCatastrales { get; set; }
        public DbSet<LinderoPredio> LinderoPredios { get; set; }
        public DbSet<Ocupante> Ocupantes { get; set; }
        public DbSet<RecapitulacionEdificio> RecapitulacionEdificios { get; set; }
        public DbSet<RecapitulacionBienComun> RecapitulacionBienComunes { get; set; }
        public DbSet<RecapBienComunComplementario> RecapBienComunComplementarios { get; set; }
        public DbSet<ReportarForma> ReportarFormas { get; set; }
        public DbSet<EvaluacionPredioCatastral> EvaluacionPredioCatastrales { get; set; }
        public DbSet<VerificadorCatastral> VerificadorCatastrales { get; set; }
        public DbSet<AreaTerrenoInvalid> AreaTerrenoInvalids { get; set; }
        public DbSet<ValorUnitario> ValorUnitarios { get; set; }
        public DbSet<ClasificacionValorUnitario> ClasificacionValorUnitarios { get; set; }
        public DbSet<ValorObraComplementaria> ValorObraComplementarias { get; set; }

        // Jurisdicciones
        public DbSet<JurisdiccionLote> JurisdiccionLotes { get; set; }


        //Habilitaciones
        public DbSet<HabilitacionUrbana> HabilitacionUrbanas { get; set; }
        public DbSet<TipoHabilitacionUrbana> TipoHabilitacionUrbanas { get; set; }

        //Vias
        public DbSet<Via> Vias { get; set; }
        public DbSet<TipoVia> TipoVias { get; set; }

        //PadronNumeraciones
        public DbSet<Numeracion> Numeraciones { get; set; }
        public DbSet<Certificado> Certificados { get; set; }
        public DbSet<OrigenNumeracion> OrigenNumeraciones { get; set; }

        //Zonificaciones
        public DbSet<LoteZonificacionParametro> LoteZonificacionParametros { get; set; }
        public DbSet<ZonificacionParametro> ZonificacionParametros { get; set; }
        public DbSet<ClaseZonificacion> ClaseZonificaciones { get; set; }




        public DbSet<Documento> Documentos { get; set; }
        public DbSet<NormaInteres> NormaInteres { get; set; }
        public DbSet<NormaDiaDetalle> NormaDiaDetalles { get; set; }
        public DbSet<NormaInteresMenu> NormaInteresMenus { get; set; }
        public DbSet<Menu> Menus { get; set; }

        #endregion

        #region Tramite  Documentario
        public DbSet<Requisito> Requisitos { get; set; }
        public DbSet<TipoDocumentoPresentado> tipoDocumentoPresentados { get; set; }
        public DbSet<TipoDocumentoSimple> tipoDocumentoSimples { get; set; }
        public DbSet<TipoInforme> TipoInformes { get; set; }
        public DbSet<TipoInspector> TipoInspectors { get; set; }
        public DbSet<TurnoInspeccion> TurnoInspeccions { get; set; }
        public DbSet<TipoDigitacion> TipoDigitacions { get; set; }
        public DbSet<Resultado> Resultados { get; set; }
        public DbSet<Moneda> Monedas { get; set; }
        public DbSet<MedioPago> MedioPagos { get; set; }
        public DbSet<MedioRegistro> MedioRegistros { get; set; }
        public DbSet<TipoNorma> TipoNormas { get; set; }
        public DbSet<EstadoNorma> EstadoNormas { get; set; }
        public DbSet<Autoridad> Autoridades { get; set; }
        public DbSet<ClasificacionNorma> ClasificacionNormas { get; set; }
        public DbSet<Naturaleza> Naturalezas { get; set; }
        public DbSet<AccionGenerar> AccionGenerars { get; set; }
        public DbSet<TipoActividad> TipoActividades { get; set; }
        public DbSet<TipoTramite> TipoTramites { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Rango> Rangos { get; set; }
        public DbSet<Procedimiento> Procedimientos { get; set; }

        public DbSet<ProcedimientoNormaInteres> ProcedimientoNormaIntereses { get; set; }
        public DbSet<CategoriaRango> CategoriaRangos { get; set; }
        public DbSet<Actividad> Actividades { get; set; }
        public DbSet<SolicitudNotificacion>SolicitudNotificaciones { get; set; }
        public DbSet<SolicitudRequisito> SolicitudRequisitos { get; set; }
        public DbSet<ProcedimientoRequisito> ProcedimientoRequisitos { get; set; }
        public DbSet<SolicitudCuc> SolicitudCucs { get; set; }
        public DbSet<ReintegroSolicitud>ReintegroSolicitudes { get; set; }
        public DbSet<ProductoCartografico> ProductoCartograficos { get; set; }
        public DbSet<Pago> Pagos { get; set; }
        public DbSet<ActividadTipoDocumento> ActividadTipoDocumentos { get; set; }

        public DbSet<Actividad> Actividads { get; set; }
        public DbSet<TramiteSolicitud> TramiteSolicituds { get; set; }
        public DbSet<SupervisorInsp> SupervisorInsps { get; set; }
        public DbSet<Inspector> Inspectors { get; set; }
        public DbSet<ActualizacionCartografico> ActualizacionCartograficos { get; set; }
        public DbSet<DerivarSolicitud> DerivarSolicituds { get; set; }
        public DbSet<ArchivoCartografico> ArchivoCartograficos { get; set; }
        public DbSet<ErrorCartograficoSolicitud> ErrorCartograficoSolicituds { get; set; }
        public DbSet<InformeTecnico> InformeTecnicos { get; set; }
        public DbSet<Solicitud> Solicitudes { get; set; }
        public DbSet<Inspeccion> Inspeccions { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<AdjuntoInforme> AdjuntoInformes { get; set; }

        #endregion

        #region   Incidencia
        public DbSet<Incidencia> Incidencias { get; set; }
        public DbSet<TipoIncidencia> TipoIncidencias { get; set; }
        #endregion

        #region Archivo
        public DbSet<TipoDocumental> TipoDocumentales { get; set; }
        public DbSet<SerieDocumental> SerieDocumentales { get; set; }
        public DbSet<SubSerieDocumental> SubSerieDocumentales { get; set; }
        public DbSet<InfDocumento> InfDocumentos { get; set; }
        public DbSet<TramiteDocumento> TramiteDocumentos { get; set; }
        public DbSet<Expediente> Expedientes { get; set; }
        public DbSet<Marcador> Marcadores { get; set; }
        public DbSet<SeccionDocumental> SeccionDocumentales { get; set; }
        #endregion

        #region Prestamo
        public DbSet<TipoPrestamo> TipoPrestamo { get; set; }
        #endregion

        public DbSet<NormaDerogada> NormaDerogada { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region admindsMap
            //modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new CargoMap());
            modelBuilder.ApplyConfiguration(new AreaMap());
            modelBuilder.ApplyConfiguration(new AreaCargoMap());
            #endregion

            #region GeneralMap
            //General
            modelBuilder.ApplyConfiguration(new InfoContactoMap());
            modelBuilder.ApplyConfiguration(new SupervisorMap());
            modelBuilder.ApplyConfiguration(new TecnicoCatastralMap());
            modelBuilder.ApplyConfiguration(new IntervencionInmuebleMap());
            modelBuilder.ApplyConfiguration(new EstadoAcabadoMap());
            modelBuilder.ApplyConfiguration(new FiliacionEstilisticaMap());
            modelBuilder.ApplyConfiguration(new ElementoArquitectonicoMap());
            modelBuilder.ApplyConfiguration(new TiempoConstruccionMap());
            modelBuilder.ApplyConfiguration(new ObservacionMap());
            modelBuilder.ApplyConfiguration(new IntervencionConservacionMap());
            modelBuilder.ApplyConfiguration(new AfectacionAntropicaMap());
            modelBuilder.ApplyConfiguration(new AfectacionNaturalMap());
            modelBuilder.ApplyConfiguration(new TipoMaterialMap());
            modelBuilder.ApplyConfiguration(new TipoArquitecturaMap());
            modelBuilder.ApplyConfiguration(new FiliacionCronologicaMap());
            modelBuilder.ApplyConfiguration(new CategoriaInmuebleMap());
            modelBuilder.ApplyConfiguration(new RepresentanteLegalMap());
            modelBuilder.ApplyConfiguration(new TipoPersonaMap());
            modelBuilder.ApplyConfiguration(new PerfilMap());
            modelBuilder.ApplyConfiguration(new UbigeoMap());
            modelBuilder.ApplyConfiguration(new LoteMap());
            modelBuilder.ApplyConfiguration(new ManzanaMap());
            modelBuilder.ApplyConfiguration(new SectorMap());
            modelBuilder.ApplyConfiguration(new DocumentoIdentidadMap());
            modelBuilder.ApplyConfiguration(new EstadoCivilMap());
            modelBuilder.ApplyConfiguration(new DomicilioMap());
            modelBuilder.ApplyConfiguration(new PersonaMap());

            modelBuilder.ApplyConfiguration(new MotivoMap());

            modelBuilder.ApplyConfiguration(new UnidadCatastralMap());
            modelBuilder.ApplyConfiguration(new TblCodigoMap());
            modelBuilder.ApplyConfiguration(new CondicionEspecialTitularMap());
            modelBuilder.ApplyConfiguration(new TipoExoneracionMap());
            modelBuilder.ApplyConfiguration(new ExoneracionTitularMap());
            modelBuilder.ApplyConfiguration(new TipoAnuncioMap());
            modelBuilder.ApplyConfiguration(new DependienteMap());
            modelBuilder.ApplyConfiguration(new AreaTratamientoMap());
            modelBuilder.ApplyConfiguration(new ReportarFormaMap());

            modelBuilder.ApplyConfiguration(new UitMap());

            #endregion

            #region ProcesosTecnicosMap
            //Procesos Tecnicos
            modelBuilder.ApplyConfiguration(new GiroAutorizadoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoFichaMap());
            modelBuilder.ApplyConfiguration(new ControlFichaMap());
            modelBuilder.ApplyConfiguration(new AntiguedadMap());
            modelBuilder.ApplyConfiguration(new ArancelMap());
            modelBuilder.ApplyConfiguration(new DepreciacionMap());
            modelBuilder.ApplyConfiguration(new CondicionNumeracionMap());
            modelBuilder.ApplyConfiguration(new CategoriaConstruccionMap());
            modelBuilder.ApplyConfiguration(new TitularCatastralMap());
            modelBuilder.ApplyConfiguration(new TipoInteriorMap());
            modelBuilder.ApplyConfiguration(new NormaIntMonColonialMap());
            modelBuilder.ApplyConfiguration(new NormaIntMonPrehiMap());
            modelBuilder.ApplyConfiguration(new MonumentoColonialMap());
            modelBuilder.ApplyConfiguration(new FichaBienCulturalMap());
            modelBuilder.ApplyConfiguration(new MonumentoPrehispanicoMap());
            modelBuilder.ApplyConfiguration(new ActividadVerificadaMap());
            modelBuilder.ApplyConfiguration(new CondicionTitularMap());
            modelBuilder.ApplyConfiguration(new CondicionEspecialPredioMap());
            modelBuilder.ApplyConfiguration(new ClasificacionPredioMap());
            modelBuilder.ApplyConfiguration(new PredioCatastralEnMap());
            modelBuilder.ApplyConfiguration(new PredioCatastralAnMap());
            modelBuilder.ApplyConfiguration(new UsoPredioMap());
            modelBuilder.ApplyConfiguration(new CondicionConductorMap());
            modelBuilder.ApplyConfiguration(new CondicionAnuncioMap());
            modelBuilder.ApplyConfiguration(new TipoAnuncioMap());
            modelBuilder.ApplyConfiguration(new EccMap());
            modelBuilder.ApplyConfiguration(new EcsMap());
            modelBuilder.ApplyConfiguration(new EdificacionIndustrialMap());
            modelBuilder.ApplyConfiguration(new MepMap());
            modelBuilder.ApplyConfiguration(new UcaMap());
            modelBuilder.ApplyConfiguration(new EstadoLlenadoMap());
            modelBuilder.ApplyConfiguration(new TipoInspeccionMap());
            modelBuilder.ApplyConfiguration(new TipoMantenimientoMap());
            modelBuilder.ApplyConfiguration(new TipoServicioBasicoMap());
            modelBuilder.ApplyConfiguration(new TipoEvaluacionMap());
            modelBuilder.ApplyConfiguration(new TipoPartidaRegistralMap());
            modelBuilder.ApplyConfiguration(new TipoTituloInscritoMap());
            modelBuilder.ApplyConfiguration(new TipoLitiganteMap());
            modelBuilder.ApplyConfiguration(new TipoDeclaratoriaMap());
            modelBuilder.ApplyConfiguration(new FormaAdquisicionMap());
            modelBuilder.ApplyConfiguration(new TipoDocNotarialMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoObraMap());
            modelBuilder.ApplyConfiguration(new EvaluacionPredioCatastralMap());
            modelBuilder.ApplyConfiguration(new VerificadorCatastralMap());
            modelBuilder.ApplyConfiguration(new AreaTerrenoInvalidMap());
            modelBuilder.ApplyConfiguration(new ValorUnitarioMap());
            modelBuilder.ApplyConfiguration(new ClasificacionValorUnitarioMap());
            modelBuilder.ApplyConfiguration(new ValorObraComplementariaMap());

            #endregion

            #region TramiteDocumentarioMap
            //tramite documentario
            modelBuilder.ApplyConfiguration(new TipoNormaMap());
            modelBuilder.ApplyConfiguration(new EstadoNormaMap());
            modelBuilder.ApplyConfiguration(new AutoridadMap());
            modelBuilder.ApplyConfiguration(new ClasificacionMap());
            modelBuilder.ApplyConfiguration(new NaturalezaMap());
            modelBuilder.ApplyConfiguration(new AccionGenerarMap());
            modelBuilder.ApplyConfiguration(new TipoActividadMap());
            modelBuilder.ApplyConfiguration(new TipoTramiteMap());
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new RangoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoPresentadoMap());
            modelBuilder.ApplyConfiguration(new TipoDocumentoSimpleMap());
            modelBuilder.ApplyConfiguration(new RequisitoMap());
            modelBuilder.ApplyConfiguration(new TipoInformeMap());
            modelBuilder.ApplyConfiguration(new TipoInspectorMap());
            modelBuilder.ApplyConfiguration(new TurnoInspeccionMap());
            modelBuilder.ApplyConfiguration(new TipoDigitacionMap());
            modelBuilder.ApplyConfiguration(new ResultadoMap());
            modelBuilder.ApplyConfiguration(new MonedaMap());
            modelBuilder.ApplyConfiguration(new MedioPagoMap());
            modelBuilder.ApplyConfiguration(new MedioRegistroMap());
            modelBuilder.ApplyConfiguration(new ProcedimientoMap());
            modelBuilder.ApplyConfiguration(new ProcedimientoNormaInteresMap());
            modelBuilder.ApplyConfiguration(new CategoriaRangoMap());
            modelBuilder.ApplyConfiguration(new ActividadMap());
            modelBuilder.ApplyConfiguration(new SolicitudNotificacionMap());
            modelBuilder.ApplyConfiguration(new SolicitudRequisitoMap());
            modelBuilder.ApplyConfiguration(new ProcedimientoRequisitoMap());
            modelBuilder.ApplyConfiguration(new SolicitudCucMap());
            modelBuilder.ApplyConfiguration(new ReintegroSolicitudMap());
            modelBuilder.ApplyConfiguration(new ProductoCartograficoMap());
            modelBuilder.ApplyConfiguration(new PagoMap());
            modelBuilder.ApplyConfiguration(new ActividadTipoDocumentoMap());

            modelBuilder.ApplyConfiguration(new ActividadMap());
            modelBuilder.ApplyConfiguration(new TramiteSolicitudMap());
            modelBuilder.ApplyConfiguration(new SupervisorInspMap());
            modelBuilder.ApplyConfiguration(new InspectorMap());
            modelBuilder.ApplyConfiguration(new ActualizacionCartograficoMap());
            modelBuilder.ApplyConfiguration(new DerivarSolicitudMap());
            modelBuilder.ApplyConfiguration(new ArchivoCartograficoMap());
            modelBuilder.ApplyConfiguration(new ErrorCartograficoSolicitudMap());
            modelBuilder.ApplyConfiguration(new InformeTecnicoMap());
            modelBuilder.ApplyConfiguration(new SolicitudMap());
            modelBuilder.ApplyConfiguration(new InspeccionMap());
            modelBuilder.ApplyConfiguration(new ProductoMap()); 
            modelBuilder.ApplyConfiguration(new AdjuntoInformeMap());

            #endregion

            modelBuilder.ApplyConfiguration(new FichaMap());
            modelBuilder.ApplyConfiguration(new TipoFichaMap());
            modelBuilder.ApplyConfiguration(new CondicionPerMap());
            modelBuilder.ApplyConfiguration(new DeclaranteMap());
            modelBuilder.ApplyConfiguration(new InfoComplementarioMap());
            modelBuilder.ApplyConfiguration(new CaracteristicaTitularidadMap());
            modelBuilder.ApplyConfiguration(new ExoneracionPredioMap());
            modelBuilder.ApplyConfiguration(new DescripcionPredioMap());
            modelBuilder.ApplyConfiguration(new EvaluacionPredioMap());
            modelBuilder.ApplyConfiguration(new ServicioBasicoMap());
            modelBuilder.ApplyConfiguration(new AutorizacionAnuncioMap());
            modelBuilder.ApplyConfiguration(new AreaActividadEconomicaMap());
            modelBuilder.ApplyConfiguration(new ConstruccionMap());
            modelBuilder.ApplyConfiguration(new FichaIndividualMap());
            modelBuilder.ApplyConfiguration(new UnidadMedidaMap());
            modelBuilder.ApplyConfiguration(new TipoOtraInstalacionMap());
            modelBuilder.ApplyConfiguration(new OtraInstalacionMap());
            modelBuilder.ApplyConfiguration(new CategoriaOrganizacionMap());
            modelBuilder.ApplyConfiguration(new ConductorMap());
            modelBuilder.ApplyConfiguration(new FichaDocumentoMap());
            modelBuilder.ApplyConfiguration(new SunarpMap());
            modelBuilder.ApplyConfiguration(new RegistroLegalMap());
            modelBuilder.ApplyConfiguration(new LitiganteMap());
            modelBuilder.ApplyConfiguration(new DocumentoObraMap());
            modelBuilder.ApplyConfiguration(new TipoResolucionMap());
            modelBuilder.ApplyConfiguration(new ResolucionMap());
            modelBuilder.ApplyConfiguration(new AutorizacionMunicipalMap());
            modelBuilder.ApplyConfiguration(new TipoEdificacionMap());
            modelBuilder.ApplyConfiguration(new TipoAgrupacionMap());
            modelBuilder.ApplyConfiguration(new EdificacionMap());
            modelBuilder.ApplyConfiguration(new UbicacionPredioMap());
            modelBuilder.ApplyConfiguration(new TipoPuertaMap());
            modelBuilder.ApplyConfiguration(new PuertaMap());
            modelBuilder.ApplyConfiguration(new TitularCatastralMap());
            modelBuilder.ApplyConfiguration(new LinderoPredioMap());
            modelBuilder.ApplyConfiguration(new OcupanteMap());
            modelBuilder.ApplyConfiguration(new RecapitulacionEdificioMap());
            modelBuilder.ApplyConfiguration(new RecapitulacionBienComunMap());
            modelBuilder.ApplyConfiguration(new RecapBienComunComplementarioMap());

            //Habilitaciones
            modelBuilder.ApplyConfiguration(new HabilitacionUrbanaMap());
            modelBuilder.ApplyConfiguration(new TipoHabilitacionUrbanaMap());

            //Vias
            modelBuilder.ApplyConfiguration(new ViaMap());
            modelBuilder.ApplyConfiguration(new TipoViaMap());

            //PadronNumeraciones
            modelBuilder.ApplyConfiguration(new NumeracionMap());
            modelBuilder.ApplyConfiguration(new CertificadoMap());
            modelBuilder.ApplyConfiguration(new OrigenNumeracionMap());

            // Jurisdicciones
            modelBuilder.ApplyConfiguration(new JurisdiccionLoteMap());

            //Zonificaciones
            modelBuilder.ApplyConfiguration(new LoteZonificacionParametroMap());
            modelBuilder.ApplyConfiguration(new ZonificacionParametroMap());
            modelBuilder.ApplyConfiguration(new ClaseZonificacionMap());



            modelBuilder.ApplyConfiguration(new DocumentoMap());
            modelBuilder.ApplyConfiguration(new NormaInteresMap());
            modelBuilder.ApplyConfiguration(new NormaDiaDetalleMap());
            modelBuilder.ApplyConfiguration(new NormaInteresMenuMap());
            modelBuilder.ApplyConfiguration(new MenuMap());

            #region   Incidencia
            modelBuilder.ApplyConfiguration(new IncidenciaMap());
            modelBuilder.ApplyConfiguration(new TipoIncidenciaMap());

            #endregion

            #region Archivo
            modelBuilder.ApplyConfiguration(new TipoDocumentalMap());
            modelBuilder.ApplyConfiguration(new SerieDocumentalMap());
            modelBuilder.ApplyConfiguration(new SubSerieDocumentalMap());
            modelBuilder.ApplyConfiguration(new InfDocumentoMap());
            modelBuilder.ApplyConfiguration(new TramiteDocumentoMap());
            modelBuilder.ApplyConfiguration(new ExpedienteMap());
            modelBuilder.ApplyConfiguration(new MarcadorMap());
            modelBuilder.ApplyConfiguration(new SeccionDocumentalMap());
            #endregion
            #region Prestamo
            modelBuilder.ApplyConfiguration(new TipoPrestamoMap());
            #endregion

            modelBuilder.ApplyConfiguration(new NormaDerogadaMap());    
        }
    }
}
