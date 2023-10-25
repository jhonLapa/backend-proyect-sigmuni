using Jca.Sigmuni.Application.Dtos.General.Sectores;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Manzanas
{
    public class ManzanaDto
    {

        public string? Id { get; set; }
        public string? Codigo { get; set; }
        public double? AreaGrafica { get; set; }
        public DateTime? FechaActualizacion { get; set; }
        public string? Editor { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? IdSectorCarto { get; set; }
        public string? Mantenimiento { get; set; }
        public SectorDto? Sector { get; set; }

    }
}
