using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Producto
    {
        public int Id { get; set; }
        public string NumCorrelativo { get; set; }
        public DateTime FechaEmision { get; set; }
        public DateTime FechaCaducidad { get; set; }
        public int Flag { get; set; }
        public int IdSolicitud { get; set; }
        public string JsonProducto { get; set; }
        public string? NumInforme { get; set; }
        public string? NumPlanoZonificacion { get; set; }
        public string? NumPlanoVia { get; set; }
        public int? IdDocumento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public bool? EsProducto { get; set; } = false;
        public string? EsProductoNombre { get => (Estado != null && Estado == false) ? "Creado" : "Generado"; }

        public virtual Solicitud Solicitud { get; set; }
        public virtual Documento Documento { get; set; }
        public Producto()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
