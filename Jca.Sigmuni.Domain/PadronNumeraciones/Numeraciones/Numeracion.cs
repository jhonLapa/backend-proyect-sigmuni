using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.Zonificaciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones
{
    public class Numeracion
    {
        public int IdNumeracion { get; set; }
        public string? NumResolucion { get; set; }
        public string? AnioResolucion { get; set; }
        public string? NumExpediente { get; set; }
        public string? AnioExpediente { get; set; }
        public string? NumInforme { get; set; }
        public DateTime? FechaEmision { get; set; }
        public string? Solicitante { get; set; }
        public string? Numero { get; set; }
        public int? IdOrigenNumeracion { get; set; }
        public int? IdTipoPuerta { get; set; }
        public string? MeAnteriorI { get; set; }
        public string? MeAnteriorII { get; set; }
        public string? MeAnteriorIII { get; set; }
        public string? MeAnteriorIV { get; set; }
        public string? MeVigente { get; set; }
        public string? MiAnteriorI { get; set; }
        public string? MiAnteriorII { get; set; }
        public string? MiAnteriorIII { get; set; }
        public string? MiAnteriorIV { get; set; }
        public string? MiVigente { get; set; }
        public string? Nivel { get; set; }
        public string? Uso { get; set; }
        public string? Folio { get; set; }
        public int? IdTblCodigo { get; set; }
        public int? IdAreaTratNormativo { get; set; }
        public int? IdClaseZonificacion { get; set; }
        public string? TotalUnidadCatastral { get; set; }
        public int? IdTipoEdificacion { get; set; }
        public int? IdTipoInteriorNUm { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdUsuario { get; set; }
        //public int? CodUnicoPuerta { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public int Estado { get; set; }
        public string Ip { get; set; }
        public string CodDistrito { get; set; }
        public string CodSector { get; set; }
        public string CodManzana { get; set; }
        public string CodLote { get; set; }
        public int? IdUnidadCatastral { get; set; }
        public int? IdTipoAsignacion { get; set; }
        public string Ubicacion { get; set; }

        public virtual TipoAsignacion TipoAsignacion { get; set; }
        public virtual OrigenNumeracion OrigenNumeracion { get; set; }
        public virtual TipoPuerta TipoPuerta { get; set; }
        public virtual TblCodigo TblCodigo { get; set; }
        public virtual AreaTratamiento AreaTratamiento { get; set; }
        public virtual ClaseZonificacion ClaseZonificacion { get; set; }
        public virtual TipoEdificacion TipoEdificacion { get; set; }
        //public virtual TipoInteriorNumeracion TipoInteriorNuInterior { get; set; }
        //public virtual Documento Documento { get; set; }
        //public virtual HUPredio HuPredio { get; set; }
        //public virtual PadronRegistro PadronRegistro { get; set; }
        //public virtual NomenclaturaPredio NomenclaturaPredio { get; set; }
        public virtual Certificado Certificado { get; set; }
    }
}
