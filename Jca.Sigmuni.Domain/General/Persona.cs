using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.Base;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using Jca.Sigmuni.Domain.Habilitaciones;
using Jca.Sigmuni.Domain.Incidencias;
using Jca.Sigmuni.Domain.ProcesosTecnicos;


namespace Jca.Sigmuni.Domain.General
{
    public class Persona 
    {
        public int Id { get; set; }
        public string? NumeroDoc { get; set; }
        public string? NumeroRuc { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdDocNatural { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdDocIdentidad { get; set; }
        public int? IdCategoriaOrganizacion { get; set; }
        public string? CodigoUbigeo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? CodigoContribuyente { get; set; }
        public string? Asociacion { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public int? IdUsuarioAccion { get; set; }
        public string? Ip { get; set; }
        public string? CartaPoder { get; set; }
        public string? NumCartaPoder { get; set; }
        public int? IdExoneracionTitular { get; set; }
        
        public virtual TipoPersona? TipoPersona { get; set; }
        public virtual EstadoCivil? EstadoCivil { get; set; }
        public virtual DocumentoIdentidad? DocumentoIdentidad { get; set; }

        public virtual Persona? RepresentanteLegalDD { get; set; }

        
        public virtual Inspector? Inspector { get; set; }
        public virtual Ocupante? Ocupante { get; set; }

        public virtual CategoriaOrganizacion? CategoriaOrganizacion { get; set; }
        public virtual Usuario? Usuario { get; set; }

        public virtual ICollection<Persona> PersonaRL { get; set; }
        public virtual ICollection<InfoContacto> InfoContacto { get; set; }
        public virtual ICollection<Solicitud> Solicitante { get; set; }
        public virtual ICollection<Solicitud> RepresentanteLegal { get; set; }
        public virtual ICollection<SupervisorInsp> SupervisorInspectores { get; set; }

     

        public virtual ICollection<Domicilio> Domicilio { get; set; }
        public virtual ICollection<Declarante> Declarantes { get; set; }
        public virtual ICollection<Supervisor> Supervisores { get; set; }
        public virtual ICollection<TecnicoCatastral> TecnicoCatastrales { get; set; }
        public virtual ICollection<Conductor> Conductores { get; set; }
        public virtual ICollection<Litigante> Litigantes { get; set; }
        //public virtual ICollection<Persona> Personas { get; set; }
        public virtual ICollection<ExoneracionTitular> ExoneracionTitulares { get; set; }
        public virtual ICollection<HabilitacionUrbana> HabilitacionesUrbanas { get; set; }
        public virtual ICollection<TitularCatastral> TitularCatastral { get; set; }
        public virtual ICollection<Dependiente> Dependientes { get; set; }
        public virtual ICollection<TramiteDocumento> TramiteDocumento { get; set; }

        public virtual ICollection<VerificadorCatastral> VerificadorCatastrales { get; set; }
        //public virtual ICollection<Incidencia> Incidencia { get; set; }
        //public virtual ICollection<Incidencia> IncidenciaInvolucrada { get; set; }

    }
}
