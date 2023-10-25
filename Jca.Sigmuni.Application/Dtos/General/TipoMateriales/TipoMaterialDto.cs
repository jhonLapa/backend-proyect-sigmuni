namespace Jca.Sigmuni.Application.Dtos.General.TipoMateriales
{
    public class TipoMaterialDto
    {
        public int IdTipoMaterial { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
