using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class Dependiente
    {
        public int Id { get; set; }
        public string Relacion { get; set; }
        public int IdPersona { get; set; }
        public int? IdTitularCatastral { get; set; }
        public int? IdLitigante { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Persona Persona { get; set; }
        public virtual TitularCatastral TitularCatastral { get; set; }
        public virtual Litigante Litigante { get; set; }
    }
}
