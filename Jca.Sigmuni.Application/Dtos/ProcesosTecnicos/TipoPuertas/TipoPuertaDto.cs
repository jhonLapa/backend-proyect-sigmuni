using System.ComponentModel.DataAnnotations;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas
{
    public class TipoPuertaDto
    {
        public int? IdTipoPuerta { get; set; }

        public string? Codigo { get; set; }

        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
