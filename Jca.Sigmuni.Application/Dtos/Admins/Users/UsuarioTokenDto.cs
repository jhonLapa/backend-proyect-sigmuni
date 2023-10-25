using System;
using Jca.Sigmuni.Core.Security.Entities;

namespace Jca.Sigmuni.Application.Dtos.Admins.Users
{
	public class UsuarioTokenDto
	{
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; }
        public int IdPerfil { get; set; }
        public int? TrabajadorPermanente { get; set; }
        public int? IdAreaCargo { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public SecurityEntity? Security { get; set; }
    }
}

