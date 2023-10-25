
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DomicilioConductores
{
    public class DomicilioConductorDto
    {
        public int IdDomicilioConductor { get; set; }
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
        public int? IdPersona { get; set; }
    }
}
