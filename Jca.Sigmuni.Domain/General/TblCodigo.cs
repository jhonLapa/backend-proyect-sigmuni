using Jca.Sigmuni.Domain.PadronNumeraciones.Numeraciones;

namespace Jca.Sigmuni.Domain.General
{
    public class TblCodigo
    {
        public int IdTblCodigo { get; set; }
        public string? CodDepartamento { get; set; }
        public string? CodProvincia { get; set; }
        public string? CodDistrito { get; set; }
        public string? CodSector { get; set; }
        public string? CodManzana { get; set; }
        public string? CodLote { get; set; }
        public string? CodEdif { get; set; }
        public string? CodEnt { get; set; }
        public string? CodPiso { get; set; }
        public string? CodUnid { get; set; }
        public string? DigitoControl { get; set; }
        public string? FlagTipo { get; set; }
        public int IdUnidadCatastral { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual UnidadCatastral UnidadCatastral { get; set; }

        public virtual ICollection<Numeracion> Numeraciones { get; set; }


    }
}
