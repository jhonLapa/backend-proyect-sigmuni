namespace Jca.Sigmuni.Application.Dtos.General.Uits
{
    public class UitDto
    {
        public long Id { get; set; }
        public double Monto { get; set; }
        public long? Porcentaje { get; set; }
        public long AnioUit { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
