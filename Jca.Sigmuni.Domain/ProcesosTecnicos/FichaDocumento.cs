using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class FichaDocumento
    {
        public int IdFichaDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public int? IdArea { get; set; }
        public int? IdFicha { get; set; }
        public int? IdTipoDocumento { get; set; }
        public decimal? TotalArea { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool Estado { get; set; } = true;

        public virtual Area Area { get; set; }
        public virtual Ficha Ficha { get; set; }
        public virtual TipoDocumentoFicha TipoDocumentoPresentado { get; set; }
    }
}
