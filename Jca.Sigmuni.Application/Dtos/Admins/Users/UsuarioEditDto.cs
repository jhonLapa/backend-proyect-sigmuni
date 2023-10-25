using System;
namespace Jca.Sigmuni.Application.Dtos.Admins.Users
{
	public class UsuarioEditDto
	{
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public int IdPerfil { get; set; }
        public int? TrabajadorPermanente { get; set; }
        public int? IdAreaCargo { get; set; }
        public DateTime? FechaAlta { get; set; }
        public DateTime? FechaBaja { get; set; }
        public int? IdCargo { get; set; }
        public int? IdArea { get; set; }
    }
}

