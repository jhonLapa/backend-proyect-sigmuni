using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
﻿using Jca.Sigmuni.Domain.Base;
using System.Runtime.CompilerServices;
using Jca.Sigmuni.Domain.Incidencias;

namespace Jca.Sigmuni.Domain.Admins
{
    public class Area 
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual ICollection<AreaCargo> AreaCargos { get; set; }
        //public virtual ICollection<FichaDocumento> FichaDocumento { get; set; }
        public virtual ICollection<Solicitud> Solicitud { get; set; }
        //public virtual ICollection<Incidencia> Incidencia { get; set; }
        public virtual ICollection<Actividad> Actividad { get; set; }
        public virtual ICollection<AreaDerivarSolicitud> AreaDerivarSolicitud { get; set; }

        public virtual ICollection<Usuario> Usuario { get; set; }
        public virtual ICollection<FichaDocumento> FichaDocumentos { get; set; }
        public virtual ICollection<Incidencia> Incidencia { get; set; }

    }
}
