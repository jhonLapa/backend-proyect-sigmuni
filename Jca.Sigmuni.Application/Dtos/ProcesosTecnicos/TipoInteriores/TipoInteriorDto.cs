namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores
{
    public class TipoInteriorDto
    {
        public int IdTipoInterior { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
