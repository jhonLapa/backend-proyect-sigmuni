using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios
{
    public class DomicilioTitularCatastralDto
    {
        public int Id { get; set; }
        public string? NumMunicipal { get; set; }
        public string? LtPrincipal { get; set; }
        public string? NumeroInterior { get; set; }
        public string? CasillaPostal { get; set; }
        public string? LtSecundario { get; set; }
        public string? LtInterior { get; set; }
        public int? IdPuerta { get; set; }

        public TipoInteriorDto? TipoInterior { get; set; }
        public HabilitacionUrbanaFichaDto? HabilitacionesUrbanas { get; set; }
        public EdificacionDto? Edificacion { get; set; }
        public ViaDto? Via { get; set; }

        public UbigeoDto? Departamento { get; set; }
        public UbigeoDto? Provincia { get; set; }
        public UbigeoDto? Ubigeo { get; set; }

        [JsonIgnore]
        public int? IdPersona { get; set; }
    }
}
