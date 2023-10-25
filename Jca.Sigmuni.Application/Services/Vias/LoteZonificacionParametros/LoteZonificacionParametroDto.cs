using Jca.Sigmuni.Application.Dtos.General.Lotes;

namespace Jca.Sigmuni.Application.Services.Vias.LoteZonificacionParametros
{
    public class LoteZonificacionParametroDto
    {
        public int Id { get; set; }
        public string IdLote { get; set; }
        public LoteDto Lote { get; set; }
        //public ZonificacionParametroDto ZonificacionParametro { get; set; }

        public bool? Estado { get; set; }
    }
}
