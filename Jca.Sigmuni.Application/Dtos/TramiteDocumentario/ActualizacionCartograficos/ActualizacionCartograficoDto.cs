using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Solicitudes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ActualizacionCartograficos
{
    public class ActualizacionCartograficoDto
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string EstadoNombre { get; set; }
        public int EsObservado { get; set; }
        public string ObservacionError { get; set; }
        public DateTime InicioCalidad { get; set; }
        public DateTime FinCalidad { get; set; }
        public int? IdInspectorCalidad { get; set; }
        public int Flag { get; set; }
        public virtual SolicitudDto Solicitud { get; set; }
    }
}
