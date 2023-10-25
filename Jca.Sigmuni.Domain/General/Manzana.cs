using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class Manzana
    {
        public string Id { get; set; }
        public string? Codigo { get; set; }
        public double? AreaGrafica { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Editor { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? IdSectorCarto { get; set; }
        public string? Mantenimiento { get; set; }

        public virtual ICollection<Lote> Lote { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual ICollection<Arancel> Arancel { get; set; }

    }
}
