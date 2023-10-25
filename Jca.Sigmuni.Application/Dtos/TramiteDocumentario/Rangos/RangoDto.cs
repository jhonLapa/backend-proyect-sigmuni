using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Rangos
{
    public class RangoDto
    {
        public int IdRango { get; set; }
        public string? PrimeraCondicion { get; set; }
        public string? SegundaCondicion { get; set; }
        public decimal PrimerValor { get; set; }
        public decimal SegundoValor { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
