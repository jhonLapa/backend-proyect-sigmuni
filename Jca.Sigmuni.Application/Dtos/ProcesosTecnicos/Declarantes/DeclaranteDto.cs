using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes
{
    public class DeclaranteDto
    {
        public int IdDeclarante { get; set; }
        public int? IdPersona { get; set; }
        public int? IdCondicionPer { get; set; }
        public int IdFicha { get; set; }
        public string? Firma { get; set; }
        public bool? TieneFirma { get; set; }
        public DateTime? Fecha { get; set; }
    }
}
