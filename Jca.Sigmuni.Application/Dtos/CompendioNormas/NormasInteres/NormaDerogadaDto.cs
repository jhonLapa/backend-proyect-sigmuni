using Jca.Sigmuni.Domain.CompendioNormas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres
{
    public class NormaDerogadaDto
    {
        public int IdNormaDerogada { get; set; }
        public string? ArticuloModificado { get; set; }
        public string? NotaObservacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int? IdEstadoNorma { get; set; }
        public int? IdNormaInteres { get; set; }
        public int? IdNormaInteresDerogada { get; set; }
        public NormaInteresFormDto? NormaInteres { get; set; }
        public NormaInteresFormDto? NormaInteresDerogada { get; set; }
    }
}
