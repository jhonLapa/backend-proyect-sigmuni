using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class InformeTecnico
    {
        public int Id { get; set; }
        public string? NumCorrelativo { get; set; }
        public DateTime FechaInforme { get; set; }
        public int Flag { get; set; }
        public int IdSolicitud { get; set; }
        public int IdEspecialista { get; set; }
        public int IdTipoInforme { get; set; }
        public string? JsonDatosSolicitud { get; set; }
        public string? JsonNumeracion { get; set; }
        public string? JsonZonificacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public bool? EsInforme { get; set; } = false;
        public string? EsInformeNombre { get => (Estado != null && Estado == false) ? "Creado" : "Generado"; }
        public virtual Solicitud? Solicitud { get; set; }
        public virtual TipoInforme? TipoInforme { get; set; }
        public virtual Usuario? Especialista { get; set; }
        public virtual ICollection<AdjuntoInforme> AdjuntoInforme { get; set; }

    }
}
