using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones
{
    public class TipoExoneracionDto
    {
        public int IdTipoExoneracion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; } = true;
    }
}
