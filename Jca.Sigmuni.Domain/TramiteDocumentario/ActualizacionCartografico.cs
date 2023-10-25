using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ActualizacionCartografico
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public int EsObservado { get; set; }
        public string ObservacionError { get; set; }
        public DateTime InicioCalidad { get; set; }
        public DateTime FinCalidad { get; set; }
        public int? IdInspectorCalidad { get; set; }
        public int Flag { get; set; }
        public virtual Solicitud Solicitud { get; set; }
        //public virtual ICollection<TecnicoCartografico> TecnicoCartografico { get; set; }
        //public virtual ICollection<ActualizacionCartoArchivo> ActualizacionCartoArchivo { get; set; }
    }
}
