using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ocupantes;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Inspectors;
using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System.Runtime.Intrinsics.Arm;

namespace Jca.Sigmuni.Application.Dtos.General.Personas
{
    public class PersonaDto
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
        public int? IdDocIdentidad { get; set; }
        public int? IdEstadoCivil { get; set; }
        public int? IdCategoriaOrganizacion { get; set; }
        public string? CodigoUbigeo { get; set; }
        public bool? Estado { get; set; }
        public DateTime FechaRegistro { get; set; }
        public string? EstadoNombre { get; set; }
        public string? CodigoContribuyente { get; set; }
        public string? Asociacion { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public int? IdUsuarioAccion { get; set; }
        public string? Ip { get; set; }
        public string? CartaPoder { get; set; }
        public string? NumCartaPoder { get; set; }
        public int? IdExoneracionTitular { get; set; }


        //public virtual TipoPersonaDto? TipoPersona { get; set; }
        //public virtual EstadoCivilDto? EstadoCivil { get; set; }
        //public virtual DocumentoIdentidadDto? DocumentoIdentidad { get; set; }
        //public virtual DomicilioDto? Domicilio { get; set; }
        //public virtual PersonaDto RepresentanteLegalDD { get; set; }
        //public UsuarioDto? Usuario { get; set; }



        public virtual TipoPersonaDto? TipoPersona { get; set; }
        public virtual EstadoCivilDto? EstadoCivil { get; set; }
        public virtual DocumentoIdentidadDto? DocumentoIdentidad { get; set; }


        public virtual InspectorDto? Inspector { get; set; }
        public virtual OcupanteDto? Ocupante { get; set; }
        public  List<InfoContactoDto>? InfoContacto { get; set; }
        public List<DomicilioDto>? Domicilio{ get; set; }
        public List<ExoneracionTitularDto>? ExoneracionTitulares{ get; set; }
        public RepresentanteLegalDto? RepresentanteLegalDD { get; set; }

        public virtual CategoriaOrganizacionDto? CategoriaOrganizacion { get; set; }
        public virtual UsuarioDto? Usuario { get; set; }

        public string NombreCompleto
        {
            get
            {
                return $"{Nombre} {Paterno} {Materno}";
            }
        }
    }
}
