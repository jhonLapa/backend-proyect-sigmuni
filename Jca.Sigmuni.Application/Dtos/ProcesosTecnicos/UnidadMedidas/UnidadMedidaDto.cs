namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UnidadMedidas
{
    public class UnidadMedidaDto
    {

        public int IdUnidadMedida { get; set; }
        //public string Codigo { get; set; }

        
        
        public string? Descripcion { get; set; }
        public string? Abreviatura { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; }
    }
}
