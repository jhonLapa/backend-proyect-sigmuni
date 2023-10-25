namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Depreciaciones
{
    public class DepreciacionPeticionDto
    {
        public string? Porcentaje { get; set; }
        public int? IdAntiguedad { get; set; }
        public int? IdEcs { get; set; }
        public int? IdMep { get; set; }
        public int? IdClasificacionPredio { get; set; }
        public bool Estado { get; set; }
    }
}
