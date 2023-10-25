using Jca.Sigmuni.Domain.Base;
using Jca.Sigmuni.Domain.CompendioNormas;
using System.Runtime.CompilerServices;

namespace Jca.Sigmuni.Domain.Admins
{
    public class Menu
    {
        public int Id { get; set; }
        public int Id_menu_padre { get; set; }
        public string Nombre { get; set; }
        public int Orden { get; set; }
        public int Nivel { get; set; }
        public string Icono { get; set; }
        public string url_menu { get; set; }
        public bool? Visible { get; set; } = true;
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }

        public virtual ICollection<NormaInteresMenu> NormaInteresMenus { get; set; }

    }
}
