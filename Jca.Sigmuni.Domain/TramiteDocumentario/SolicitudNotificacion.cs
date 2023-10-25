using Jca.Sigmuni.Domain.Admins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class SolicitudNotificacion
    {
        public int Id { get; set; }
        public string NumeroNotificacion { get; set; }
        public string Asunto { get; set; }
        public string Referencia { get; set; }
        public string Observacion { get; set; }
        public string Correo { get; set; }
        public int? IdSolicitud { get; set; }
        public int? IdUsuario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;

        //public virtual Solicitud Solicitud { get; set; }
        public virtual Usuario Usuario { get; set; }

        public SolicitudNotificacion()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
