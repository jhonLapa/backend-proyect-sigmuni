using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.TramiteDocumentario;

namespace Jca.Sigmuni.Domain.Jurisdiccion
{
    public class JurisdiccionLote
    {
        public int IdJurisdiccion { get; set; }

        public string? NumeroOficioIcl { get; set; }

        public string? NumeroOficioImp { get; set; }

        public string? Nota { get; set; }

        public string? IdLoteCarto { get; set; }

        public string? CodigoUbigeo { get; set; }
        public int? IdSolicitud { get; set; }

        public string? numPlanoIGN { get; set; }

        public DateTime? FechaOficioIMP { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;


        public virtual Ubigeo? Ubigeo { get; set; }
        public virtual Lote? Lote { get; set; }
        public virtual Solicitud? Solicitud { get; set; }

        // public virtual ICollection<JurisdiccionNormaInteres> JurisdiccionNormaInteres { get; set; }
       //  public virtual ICollection<JurisdiccionImpNormaInteres> JurisdiccionImpNormaInteres { get; set; }

       //  public virtual ICollection<JurisdiccionFichaTecnica> JurisdiccionFichaTecnica { get; set; }
    }
}
