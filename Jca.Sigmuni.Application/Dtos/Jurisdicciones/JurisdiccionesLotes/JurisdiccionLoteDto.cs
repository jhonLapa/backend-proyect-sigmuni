using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;

namespace Jca.Sigmuni.Application.Dtos.Jurisdicciones.JurisdiccionesLotes
{
    public class JurisdiccionLoteDto
    {
        public int IdJurisdiccion { get; set; }

        public string? NumeroOficioIcl { get; set; }

        public string? NumeroOficioImp { get; set; }

        public string? Nota { get; set; }

        public string? IdLoteCarto { get; set; }

        public string? CodigoUbigeo { get; set; }
        public string? IdSolicitud { get; set; }

        public string? numPlanoIGN { get; set; }

        public DateTime? FechaOficioIMP { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        public virtual UbigeoDto? Ubigeo { get; set; }
        public virtual LoteDto? Lote { get; set; }
    }
}
