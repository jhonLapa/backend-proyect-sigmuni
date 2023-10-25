using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.ProductoCartos
{
    public class ProductoCartoDto
    {
        public int Id { get; set; }
        public int IdInspector { get; set; }
        public int IdSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public int Flag { get; set; }
        public int Folios { get; set; }
        public int? IdDocumento { get; set; }
        public int? IdRemitente { get; set; }
        public int EsObservado { get; set; }
        public int Derivado { get; set; }
        public DateTime InicioCalidad { get; set; }
        public DateTime FinCalidad { get; set; }
        public string ObservacionError { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
        public int? IdInspectorCalidad { get; set; }
    }
}
