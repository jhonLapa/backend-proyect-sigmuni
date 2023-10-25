﻿namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Resultado
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Grupo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual ICollection<Actividad> Actividades { get; set; }
        public virtual ICollection<Actividad> ActividadesResultado2 { get; set; }
        //public virtual ICollection<TramiteSolicitud> TramiteSolicitudes { get; set; }
        public virtual ICollection<SolicitudCuc>? SolicitudCuc { get; set; }
        //public virtual ICollection<InspeccionCuc> InspeccionCuc { get; set; }

        public virtual ICollection<TramiteSolicitud> TramiteSolicitudes { get; set; }
        //public virtual ICollection<SolicitudCuc> SolicitudCuc { get; set; }
        //public virtual ICollection<InspeccionCuc> InspeccionCuc { get; set; }


    }
}
