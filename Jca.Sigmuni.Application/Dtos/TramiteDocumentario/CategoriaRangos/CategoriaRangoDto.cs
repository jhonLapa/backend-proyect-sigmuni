using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Categorias;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Procedimientos;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.Rangos;
using Jca.Sigmuni.Domain.TramiteDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos
{
    public class CategoriaRangoDto
    {
        public int Id { get; set; }
        public int Anio { get; set; }
        public Decimal PorcentajeUit { get; set; }
        public Decimal Importe { get; set; }
        public int PlazoResolver { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdRango { get; set; }
        public int? IdProcedimiento { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public CategoriasDto? Categoria { get; set; }
        public RangoDto? Rango { get; set; }
        public ProcedimientoDto? Procedimiento { get; set; }
    }
}
