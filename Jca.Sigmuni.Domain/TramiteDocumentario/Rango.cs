using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Rango
    {
        public int IdRango { get; set; }
        public string? PrimeraCondicion { get; set; }
        public string? SegundaCondicion { get; set; }
        public decimal PrimerValor { get; set; }
        public decimal SegundoValor { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual ICollection<CategoriaRango> CategoriaRango { get; set; }
    }
}
