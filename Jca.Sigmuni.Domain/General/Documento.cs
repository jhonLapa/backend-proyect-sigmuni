using Jca.Sigmuni.Domain.ArchivoDocumentario;
using Jca.Sigmuni.Domain.Incidencias;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class Documento
    {
        public int IdDocumento { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }
        public byte[]? Contenido { get; set; }
        public string? MineType { get; set; }
        public string? Extencion { get; set; }
        public string? NombreOriginal { get; set; }
        public string? UbicacionFisica { get; set; }


        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;

        public virtual ICollection<DerivarSolicitud> DerivarSolicitud { get; set; }
        public virtual ICollection<ArchivoCartografico> ArchivoCartografico { get; set; }
        public virtual ICollection<TramiteSolicitud> TramiteSolicitud { get; set; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }
        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }
        public virtual ICollection<SolicitudRequisito> SolicitudRequisito { get; set; }
        public virtual ICollection<Expediente> Expediente { get; set; }
        public virtual ICollection<Producto> Producto { get; set; }
        public virtual ICollection<AdjuntoInforme> AdjuntoInforme { get; set; }

    }
}
