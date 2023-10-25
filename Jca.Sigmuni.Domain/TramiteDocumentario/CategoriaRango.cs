using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class CategoriaRango
    {
        public int Id { get; set; }
        public int? Anio { get; set; }
        public Decimal? PorcentajeUit { get; set; }
        public Decimal? Importe { get; set; }
        public int? PlazoResolver { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdRango { get; set; }
        public int? IdProcedimiento { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual Procedimiento Procedimiento { get; set; }
        public virtual Categoria Categoria { get; set; }
        public virtual Rango Rango { get; set; }

      
    }
}
