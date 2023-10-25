using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Procedimiento
    {
        public int Id { get; set; }
        public string? AsuntoTramite { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
        public int? IdUsuario { get; set; }
        public int? IdTipoTramite { get; set; }
        public string? Normativa { get; set; }
        public string? PlazoResolver { get; set; }
        public string? PlazoReconsAdministrativo { get; set; }
        public string? PlazoReconsIcl { get; set; }
        public string? PlazoApelAdministrativo { get; set; }
        public string? PlazoApelIcl { get; set; }
        public string? PlazoRevAdministrativo { get; set; }
        public string? PlazoRevIcl { get; set; }
        public int? RequiereCuc { get; set; }
        public string? Codigo { get; set; }
        public int? EsParaVirtual { get; set; }

        public virtual TipoTramite? TipoTramite  { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public virtual ICollection<ProcedimientoNormaInteres>? ProcedimientoNormaInteres { get; set; }
        ////public virtual ICollection<CategoriaRango> CostoProcedimiento { get; set; } //erey Mesa Partes
        public virtual ICollection<Solicitud> Solicitud { get; set; } //erey Mesa Partes
        public virtual ICollection<ProcedimientoRequisito>? ProcedimientoRequisito { get; set; } //erey Mesa Partes
        public virtual ICollection<CategoriaRango>? CategoriaRango { get; set; }
        public ICollection<Actividad>? Actividad { get; set; }

        public Procedimiento()
        {
            FechaRegistro = DateTime.UtcNow;

        }
    }
}
