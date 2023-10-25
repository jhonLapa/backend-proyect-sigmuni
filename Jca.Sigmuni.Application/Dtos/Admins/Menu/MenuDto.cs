using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Menu
{
    public class MenuDto
    {
        public int Id { get; set; }
        public int Id_menu_padre { get; set; }
        public string? Nombre { get; set; }
        public int Orden { get; set; }
        public int Nivel { get; set; }
        public string? Icono { get; set; }
        public string? url_menu { get; set; }
        public bool? Visible { get; set; } = true;
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
    }
}
