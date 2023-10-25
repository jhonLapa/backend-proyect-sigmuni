using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocNotariales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RegistroLegales
{
    public class RegistroLegalDto
    {
        public string? IdRegistroLegal { get; set; }
        public string? Notaria { get; set; }
        public string? Kardex { get; set; }
        public DateTime? FechaEscritura { get; set; }
        public TipoDocNotarialDto? TipoDocNotarial { get; set; }
        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
