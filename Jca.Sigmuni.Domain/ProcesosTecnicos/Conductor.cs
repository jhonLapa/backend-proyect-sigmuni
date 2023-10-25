using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Conductor
    {
        public int IdConductor { get; set; }
        public int? IdCondicionConductor { get; set; }
        public int? IdPersona { get; set; }
        public int IdFicha { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public string? NombreComercial { get; set; }
        public string? NombreAsociacion { get; set; }
        public int? NumTrabajadores { get; set; }
        public bool? Estado { get; set; } = false;

        public virtual CondicionConductor CondicionConductor { get; set; }
        public virtual Persona Persona { get; set; }
        public virtual Ficha Ficha { get; set; }
    }
}
