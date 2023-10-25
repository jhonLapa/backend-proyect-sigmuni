using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Fichas
{
    public class BienCommunPeticionDto
    {
        public string? CodDistrito { get; set; }
        public string? CodSector { get; set; }
        public string? CodManzana { get; set; }
        public string? CodLote { get; set; }
        public string? CodEdif { get; set; }
        public string? CodEnt { get; set; }
        public string? CodPiso { get; set; }
        public string? CodUnid { get; set; }
        public int? Anio { get; set; }
        public string? tipoFichaBienComun { get; set; }
    }
}
