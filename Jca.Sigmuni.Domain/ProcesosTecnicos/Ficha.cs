using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Ficha
    {
        public int IdFicha { get; set; }
        public string? NumExpediente { get; set; }
        public string? NtTf { get; set; }
        public string? NumFicha { get; set; }
        public double? Dc { get; set; }
        public int IdTipoFicha { get; set; }
        public int IdUnidadCatastral { get; set; }
        public string IdLoteCarto { get; set; }
        public int? AnioFicha { get; set; }
        public int? IdFichaPadre { get; set; }
        public string? TipoBienComun { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public int Estado { get; set; }

        public virtual Usuario? Usuario { get; set; }
        public virtual TipoFicha? TipoFicha { get; set; }
        public virtual UnidadCatastral? UnidadCatastral { get; set; }

        public virtual ICollection<Declarante> Declarantes { get; set; }
        public virtual ICollection<Supervisor> Supervisores { get; set; }
        public virtual ICollection<TecnicoCatastral> TecnicoCatastrales { get; set; }
        public virtual ICollection<DescripcionPredio> DescripcionPredios { get; set; }
        public virtual ICollection<EvaluacionPredio> EvaluacionPredios { get; set; }
        public virtual ICollection<ServicioBasico> ServicioBasicos { get; set; }
        public virtual ICollection<AutorizacionAnuncio> AutorizacionAnuncios { get; set; }
        public virtual ICollection<AreaActividadEconomica> AreaActividadEconomicas { get; set; }
        public virtual ICollection<Conductor> Conductores { get; set; }
        public virtual ICollection<Construccion> Construcciones { get; set; }
        public virtual ICollection<FichaIndividual> FichaIndividuales { get; set; }
        public virtual ICollection<TitularCatastral> TitularCatastral { get; set; }
        public virtual ICollection<AutorizacionMunicipal> AutorizacionMunicipales { get; set; }
        public virtual ICollection<OtraInstalacion> OtraInstalaciones { get; set; }
        public virtual ICollection<FichaDocumento> FichaDocumentos { get; set; }
        public virtual ICollection<Sunarp> Sunarps { get; set; }
        public virtual ICollection<RegistroLegal> RegistroLegales { get; set; }
        public virtual ICollection<Litigante> Litigantes { get; set; }
        public virtual ICollection<DocumentoObra> DocumentoObras { get; set; }
        public virtual ICollection<Resolucion> Resoluciones { get; set; }
        public virtual ICollection<UbicacionPredio> UbicacionPredios { get; set; }
        public virtual ICollection<InfoComplementario> InfoComplementarios { get; set; }
        public virtual ICollection<Ocupante> Ocupantes { get; set; }
        public virtual ICollection<FichaBienCultural> FichaBienCulturales { get; set; }
        public virtual ICollection<RecapitulacionEdificio> RecapitulacionEdificios { get; set; }
        public virtual ICollection<RecapitulacionBienComun> RecapitulacionBienComunes { get; set; }
        public virtual ICollection<RecapBienComunComplementario> RecapBienComunComplementarios { get; set; }
        public virtual ICollection<EvaluacionPredioCatastral> EvaluacionPredioCatastrales { get; set; }
        public virtual ICollection<VerificadorCatastral> VerificadorCatastrales { get; set; }
        public virtual ICollection<AreaTerrenoInvalid> AreaTerrenoInvalids { get; set; }
    }
}
