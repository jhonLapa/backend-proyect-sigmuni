using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Manzanas
{
    public class ManzanaBusquedaDto
    {
        public string? IdManzanaCarto { get; set; }
        public string? CodigoUbigeo { get; set; }
        public string? CodigoSector { get; set; }
        public string? CodigoManzana { get; set; }
        public string? NombreVia { get; set; }
        public string? Cuadra { get; set; }
        public string? HabilitacionUrbana { get; set; }
        public string? TipoAgrupacion { get; set; }
        public string? NumeroLote { get; set; }
        public string? ManzanaUrbana { get; set; }
        public string? Anio { get; set; }
        public string? Lado { get; set; }
    }
}
