using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class ProductoCartografico
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
        //public virtual Inspector Inspector { get; set; }
        //public virtual Solicitud Solicitud { get; set; }
        //public virtual Documento Documento { get; set; }
        //public virtual ICollection<ProductoCartoArchivo> ProductoCartoArchivo { get; set; }

        public ProductoCartografico()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
