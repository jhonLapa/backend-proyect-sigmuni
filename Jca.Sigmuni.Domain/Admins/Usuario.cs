using System;
using Jca.Sigmuni.Domain.Base;
using Jca.Sigmuni.Domain.CompendioNormas;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;



namespace Jca.Sigmuni.Domain.Admins
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; }
        public string Clave { get; set; }
        [ObsoleteAttribute("This property is obsolete. Now it is not necessary.", false)]
        public string? ClaveSalt { get; set; }
        public int IdPerfil { get; set; }
        public int? TrabajadorPermanente { get; set; }
        public int? IdAreaCargo { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }
        public string? ClaveAlterna { get; set; }
        [ObsoleteAttribute("This property is obsolete. Now it is not necessary.", false)]
        public string? ClaveSaltAlterna { get; set; }

        public virtual Perfil Perfil { get; set; }
        public virtual Cargo Cargo { get; set; }
        public virtual Area Area { get; set; }
        public virtual Persona Persona { get; set; }

        public virtual ICollection<InformeTecnico> InformeTecnico { get; set; }

        //public virtual ICollection<NormaInteres> NormaInteres { get; set; }
        public virtual ICollection<Procedimiento> Procedimientos { get; set; }
        //public virtual ICollection<NormaDia> NormaDia { get; set; }
        public virtual ICollection<SolicitudNotificacion> SolicitudNotificacion { get; set; }


        public virtual ICollection<Ficha> Fichas { get; set; }

    }
}

