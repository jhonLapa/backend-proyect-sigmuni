using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.Admins.Users;
using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDocumentoPresentados;
using Jca.Sigmuni.Domain.Admins;

namespace Jca.Sigmuni.Application.Dtos.General.Personas
{
    public class PersonaFormDto
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
        public string? CodigoContribuyente { get; set; }
        public string? Asociacion { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public int? IdUsuarioAccion { get; set; }
        public string? Ip { get; set; }
        public string? CartaPoder { get; set; }
        public string? NumCartaPoder { get; set; }
        public int? IdExoneracionTitular { get; set; }

        public RepresentanteLegalDto? RepresentanteLegal { get; set; }
        public UsuarioCreateDto? Usuario { get; set; }
        public DomicilioDto? Domicilio { get; set; }
        public TipoPersonaDto? TipoPersona { get; set; }  
        public EstadoCivilDto? EstadoCivil { get; set; }
        public TipoDocumentoPresentadoDto? TipoDocumento { get; set; }
        public InfoContactoDto? InfoContacto { get; set; }
        public ExoneracionTitularDto? ExoneracionTitular { get; set; }
        public CategoriaOrganizacionDto? CategoriaOrganizacion { get; set; }
        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }
    }
}
