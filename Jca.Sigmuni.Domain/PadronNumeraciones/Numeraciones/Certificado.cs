

namespace Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones
{
    public class Certificado
    {
        public int Id { get; set; }
        public string NumCertificadoExterior { get; set; }
        public int AnioCertificadoExterior { get; set; }
        public string NumCertificadoInterior { get; set; }
        public int AnioCertificadoInterior { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public Numeracion Numeracion { get; set; }
    }
}
