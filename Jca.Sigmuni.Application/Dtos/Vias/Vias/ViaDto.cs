using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;

namespace Jca.Sigmuni.Application.Dtos.Vias.Vias
{
    public class ViaDto
    {
        public string? IdVia { get; set; }
        public string? CodVia { get; set; }
        public string? Nombre { get; set; }
        public string? NomenclaturaHistoricoI { get; set; }
        public string? NomenclaturaHistoricoII { get; set; }
        public string? NumeroCuadra { get; set; }
        public string? Frente { get; set; }
        public string? Nota { get; set; }
        public string? Observacion { get; set; }
        public DateTime? FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? CodigoUbigeo { get; set; }
        public int? IdLado { get; set; }
        public int? IdTipoVia { get; set; }
        public int? IdUsuario { get; set; }
        public UbigeoDto? Ubigeo { get; set; }
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        //public LadoDto Lado { get; set; }
        //public DocumentoDto Documento { get; set; }
        public TipoViaDto? TipoVia { get; set; }
        // public List<ViaNormaInteresDto> ViaNormaIntereses { get; set; }
        //public List<ViaTramoDto> ViaTramo { get; set; }




    }
}
