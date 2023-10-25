using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.InformeTecnicos
{
    public class InformeTecnicoRespuestaDto
    {
        public int Id { get; set; }
        public string NumCorrelativo { get; set; }
        public DateTime FechaInforme { get; set; }
        public int Flag { get; set; }
    }
}
