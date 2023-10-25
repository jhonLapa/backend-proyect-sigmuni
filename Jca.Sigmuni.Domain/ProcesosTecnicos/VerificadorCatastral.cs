using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class VerificadorCatastral
    {
        public int Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdCondicionPer { get; set; }
        public int? IdFicha { get; set; }
        public string? NumeroRegistro { get; set; }
        public bool? TieneFirma { get; set; }
        public DateTime? Fecha { get; set; }

        public virtual Persona? Persona { get; set; }
        public virtual CondicionPer? CondicionPer { get; set; }
        public virtual Ficha? Ficha { get; set; }
    }
}
