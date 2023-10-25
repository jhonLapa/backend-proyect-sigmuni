using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ArancelBusqueda
    {
        public int IdArancel { get; set; }
        public int? Anio { get; set; }
        public string? IdVia { get; set; }
        public string? IdManzana { get; set; }
        public string? IdSector { get; set; }
        public int? IdTipoVia { get; set; }
        public decimal? Valor { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
    }
}
