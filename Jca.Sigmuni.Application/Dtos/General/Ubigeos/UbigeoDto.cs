using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Ubigeos
{
    public class UbigeoDto
    {
        public string? Codigo { get; set; }
        public string? CodigoPadre { get; set; }
        public string? CodigoParcial { get; set; }
        public string? Nombre { get; set; }

        public int? Nivel { get; set; }


        public string? NombreCompleto { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
    }
}
