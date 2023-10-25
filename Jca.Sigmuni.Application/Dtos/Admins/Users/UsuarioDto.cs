using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.Admins.Cargos;
using Jca.Sigmuni.Application.Dtos.General.Perfiles;
using Jca.Sigmuni.Application.Dtos.General.Personas;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users
{
    public class UsuarioDto
    {
        public int Id { get; set; }
        public string? NombreUsuario { get; set; }
        public string? Clave { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; }
        public int IdPerfil { get; set; }
        public int? TrabajadorPermanente { get; set; }
        public int? IdAreaCargo { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }
        public CargoDto? Cargo { get; set; }
        public AreaDto? Area { get; set; }
        public PerfilDto? Perfil { get; set; }
        public PersonaSolicitudDto? Persona { get; set; }
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
    }
}
