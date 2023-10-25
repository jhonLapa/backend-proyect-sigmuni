namespace Jca.Sigmuni.Application.Dtos.General.EstadosAcabados
{
    public class EstadoAcabadoDto
    {
        public int IdEstadoAcabado { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        
        public bool? Estado { get; set; } = true;
    }
}
