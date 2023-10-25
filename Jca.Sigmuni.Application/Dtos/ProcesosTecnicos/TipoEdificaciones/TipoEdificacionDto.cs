using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEdificaciones
{
    public class TipoEdificacionDto
    {
        public int? IdTipoEdificacion { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
