namespace Jca.Sigmuni.Application.Dtos.General.Perfiles
{
    public class PerfilDto
    {
        public int Id { get; set; }
        public string? Descripcion { get; set; }
        public string? Nombre { get; set; }
        public string Etiqueta { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }

    }
}
