using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Personas
{
    public class PersonaSolicitudFormDto
    {
        public int Id { get; set; }
        public string? NumeroDoc { get; set; }
        public string? NumeroRuc { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? RazonSocial { get; set; }
        public string? Direccion { get; set; }
        public DomicilioDto? Domicilio { get; set; }
        public InfoContactoFormDto? InfoContacto { get; set; }
        public TipoPersonaDto? TipoPersona { get; set; }
        public EstadoCivilDto? EstadoCivil { get; set; }
        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }
        public CategoriaOrganizacionDto? CategoriaOrganizacion { get; set; }
    }
}
