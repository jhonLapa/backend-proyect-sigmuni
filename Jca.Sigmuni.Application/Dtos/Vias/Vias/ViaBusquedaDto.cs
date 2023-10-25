using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Vias.Vias
{
    public class ViaBusquedaDto
    {
        public string? IdVia { get; set; }
        public string? CodVia { get; set; }
        public string? Nombre { get; set; }
        public string? NomenclaturaHistoricoI { get; set; }
        public string? NomenclaturaHistoricoII { get; set; }
        public string? NumeroCuadra { get; set; }
        public string? Frente { get; set; }
        public string? Nota { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? CodigoUbigeo { get; set; }
        public int? IdLado { get; set; }
        public int? IdTipoVia { get; set; }
        public int? IdUsuario { get; set; }
    }
}
