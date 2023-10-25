using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionConductores;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Conductores
{
    public class ConductorDto
    {
        public int IdConductor { get; set; }
        public int? IdCondicionConductor { get; set; }
        public int? IdPersona { get; set; }
        public int IdFicha { get; set; }
        public int? IdRepresentanteLegal { get; set; }
        public string? NombreComercial { get; set; }
        public string? NombreAsociacion { get; set; }
        public int? NumTrabajadores { get; set; }
        public bool? Estado { get; set; } = false;
        public string? NumeroDni { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? NumeroRuc { get; set; }
        public string? RazonSocial { get; set; }
        public CategoriaOrganizacionDto? CategoriaOrganizacion { get; set; }

        public CondicionConductorDto? CondConductor { get; set; }

        public InfoContactoDto? Contacto { get; set; }
        public TipoPersonaDto? TipoPersona { get; set; }
        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }


       
    }
}
