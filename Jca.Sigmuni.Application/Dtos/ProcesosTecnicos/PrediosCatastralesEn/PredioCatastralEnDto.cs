namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn
{
    public class PredioCatastralEnDto
    {
        public int IdPredioCatastralEn { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
