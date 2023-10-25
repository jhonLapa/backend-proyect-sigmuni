using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ControlFichas
{
    public class ControlFichaDto
    {
        public int? Id { get; set; }
        public int? IdUnidadCatastral { get; set; }
        public int? IdFicha { get; set; }
        public string? NombreFicha { get; set; }
        public string? NombreTab { get; set; }
        public string? NombreCampo { get; set; }
        public string? ValorAnterior { get; set; }
        public string? ValorActual { get; set; }
        public bool EsConforme { get; set; }
        public string? Observacion { get; set; }
        public int? IdUsuario { get; set; }
        public int? Estado { get; set; }
    }
}
