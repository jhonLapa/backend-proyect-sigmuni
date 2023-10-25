namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Antiguedades
{
    public class AntiguedadDto
    {
        public int IdAntiguedad { get; set; }
        public string? PrimeraCondicion { get; set; }
        public int? LimiteInferior { get; set; }
        public string? SegundaCondicion { get; set; }
        public int? LimiteSuperior { get; set; }
        public string? Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}
