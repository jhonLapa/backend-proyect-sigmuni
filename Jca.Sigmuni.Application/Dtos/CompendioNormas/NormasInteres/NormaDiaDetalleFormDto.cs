using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres
{
    public class NormaDiaDetalleFormDto
    {
        public int IdNormaDiaDetalle { get; set; }
        public int IdNormaDia { get; set; }
        public string? Nombre { get; set; }
        public string? Sumilla { get; set; }
        public bool? Estado { get; set; }
        public bool? FlagNotificacion { get; set; }
        public string? Enlace { get; set; }
        public int IdAutoridad { get; set; }
    }
}
