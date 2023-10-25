using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Cargos
{
    public class CargoDto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
    }
}
