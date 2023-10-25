using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoResoluciones
{
    public class TipoResolucionDto
    {
        public string IdTipoResolucion { get; set; }

        [Required(ErrorMessage = "Código es requerido")]
        [MaxLength(10, ErrorMessage = "Como máximo se puede ingresar 10 letras")]
        public string Codigo { get; set; }

        [Required(ErrorMessage = "Descripción es requerido")]
        [MaxLength(100, ErrorMessage = "Como máximo se puede ingresar 100 letras")]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
