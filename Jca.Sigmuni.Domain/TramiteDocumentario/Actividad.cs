using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Actividad
    {
        public int Id { get; set; }
        public int? NumeroActividad { get; set; }
        public int? NumeroActividadAnterior { get; set; }
        public int? NumeroActividadSiguiente { get; set; }
        public string? Descripcion { get; set; }
        public int? PlazoAtencion { get; set; }
        public int? NotificacionCorreo { get; set; }
        public int? Flag { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public int? IdTipoActividad { get; set; }
        public int? IdProcedimiento { get; set; }
        public int? IdAccionGenerar { get; set; }
        public int? IdAreaCargo { get; set; }
        public string UltimoPaso { get; set; }
        public string Observacion { get; set; }
        public int? IdResultado { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdResultadoII { get; set; }
        public int? IdArea { get; set; }


        public virtual TipoActividad? TipoActividad { get; set; }
        public virtual Procedimiento? Procedimiento { get; set; }
        public virtual AccionGenerar? AccionGenerar { get; set; }
        public virtual Resultado? Resultado { get; set; }
        public virtual Resultado? ResultadoII { get; set; }
        public virtual Solicitud? Solicitud { get; set; }
        public virtual Area? Area { get; set; }
        public virtual ICollection<TramiteSolicitud> TramiteSolicitudes { get; set; }


    }
}
