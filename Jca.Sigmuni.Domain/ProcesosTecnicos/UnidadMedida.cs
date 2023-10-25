namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class UnidadMedida
    {
        public int IdUnidadMedida { get; set; }
        public string? Descripcion { get; set; }
        public string? Abreviatura { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual ICollection<MonumentoPrehispanico> MonumentoPreinspanico { get; set; }
        public virtual ICollection<TipoOtraInstalacion> TipoOtraInstalaciones { get; set; }
        public virtual ICollection<OtraInstalacion> OtraInstalaciones { get; set; }
    }
}
