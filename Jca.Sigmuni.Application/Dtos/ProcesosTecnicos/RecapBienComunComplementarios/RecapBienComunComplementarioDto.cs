using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapBienComunComplementarios
{
    public class RecapBienComunComplementarioDto
    {
        public int? Id { get; set; }
        public string? AnchoPasaje { get; set; }
        public string? Distancia { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
