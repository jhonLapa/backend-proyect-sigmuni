using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class UnidadCatastral
    {
        public int IdUnidadCatastral { get; set; }
        public string? CodigoCatastral { get; set; }
        public string? CodigoHojaCatastral { get; set; }
        public string? CodigoPredialSat { get; set; }
        public string? UnidadAcumuladaCodigo { get; set; }
        public string? Correlativo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdMotivo { get; set; }
        public string? CodigoRefCatastral { get; set; }
        public string? Ambito { get; set; }
        public string? IdLoteCarto { get; set; }
        public int? AnioUltimoDDJJ { get; set; }
        public string? Cuc { get; set; }

        public virtual Lote Lote { get; set; }

        public virtual ICollection<TblCodigo> TblCodigo { get; set; }
        public virtual ICollection<Ficha> Fichas { get; set; }
        // public virtual ICollection<ImagenPredio> ImagenPredio { get; set; }
        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }
        //public virtual ICollection<ControlFicha> ControlFicha { get; set; }
        //public virtual Motivo Motivo { get; set; }
    }
}
