namespace Jca.Sigmuni.Application.Dtos.General.CategoriaInmuebles
{
    public class CategoriaInmuebleDto
    {
        public int IdCategoriaInmueble { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
