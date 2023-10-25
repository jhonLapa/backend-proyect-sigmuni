using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesNumeraciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPuertas;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Puertas
{
    public class PuertaDto
    {
        public int IdPuerta { get; set; }
        public string? CodigoPuerta { get; set; }
        public string? NumeracionMunicipal { get; set; }
        public string? IdLoteCartografia { get; set; }
        public string? LtPrincipal { get; set; }
        public string? LtScundario { get; set; }
        public string? NumCertifPrincipal { get; set; }
        public string? NumCertifSecundario { get; set; }
        //public string? AnioPrincipal { get; set; }
        public string? AnioSecundario { get; set; }
        public string? NumeroInterior { get; set; }

        public TipoPuertaDto? TipoPuerta { get; set; }
        public ViaDto? Via { get; set; }
        public CondicionNumeracionDto? CondicionNumeracion { get; set; }
        //public CondicionNumeracionDto CondNumSecundario { get; set; }
        //public TipoNumeracionDto TipoNumPrincipal { get; set; }
        //public TipoNumeracionDto TipoNumSecundario { get; set; }
        //public UbicacionNumeracionDto UbicacionNumeracion { get; set; }
        public TipoInteriorDto? TipoInterior { get; set; }

        [JsonIgnore]
        public int IdUbicacionPredio { get; set; }

        [JsonIgnore]
        public int IdTblCodigo { get; set; }
    }
}
