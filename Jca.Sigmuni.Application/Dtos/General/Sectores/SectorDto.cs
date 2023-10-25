using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Sectores
{
    public class SectorDto
    {
        public string? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }


        public int? AreaGrafica { get; set; }


        public string? CodigoUbigeo { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public UbigeoDto? Ubigeo { get; set; }
    }
}
