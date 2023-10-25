using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoTituloInscritos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Sunarps
{
    public class SunarpDto
    {
        public int Id { get; set; }
        public string? NumeroPartida { get; set; }
        public string? Fojas { get; set; }
        public string? Asiento { get; set; }
        public string? DeclaratoriaFabrica { get; set; }

        public DateTime? FechaInscripcion { get; set; }
        public string? AsientoFabrica { get; set; }
        public DateTime? FechaFabrica { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }

        [JsonIgnore]
        public int? IdMonumentoPre { get; set; }

        [JsonIgnore]
        public int? IdMonumentoColonial { get; set; }

        public TipoPartidaRegistralDto? TipoPartidaRegistral { get; set; }

        public TipoTituloInscritoDto? TipoTituloInscrito { get; set; }
    }
}
