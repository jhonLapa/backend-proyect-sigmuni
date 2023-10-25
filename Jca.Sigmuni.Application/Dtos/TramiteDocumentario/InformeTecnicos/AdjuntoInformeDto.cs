using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class AdjuntoInformeDto
    {
        [Required(ErrorMessage = "ID Informe Requerido")]
        public int IdInformeTecnico { get; set; }
        [Required(ErrorMessage = "ID documento requerido")]
        public int IdDocumento { get; set; }
        public int Flag { get; set; }
    }
}
