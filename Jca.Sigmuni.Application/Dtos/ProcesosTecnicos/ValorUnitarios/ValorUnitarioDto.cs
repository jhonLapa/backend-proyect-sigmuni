using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CategoriaConstrucciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionValorUnitarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ValorUnitarios
{
    public class ValorUnitarioDto
    {
        public int IdValorUnitario { get; set; }
        public int? Anio { get; set; }
        public string? Descripcion { get; set; }
        public decimal? Valor { get; set; }
        public int? IdClasificacionValUnitario { get; set; }
        public int? IdCategoriaValUnitario { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }

        public ClasificacionValorUnitarioDto? ClasificacionValorUnitario { get; set; }
        public CategoriaConstruccionDto? CategoriaValorUnitario { get; set; }
    }
}
