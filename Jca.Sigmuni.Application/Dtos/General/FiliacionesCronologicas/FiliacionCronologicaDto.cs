namespace Jca.Sigmuni.Application.Dtos.General.FiliacionesCronologicas
{
    public class FiliacionCronologicaDto
    {
        public int IdFiliacionCronologica { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
