using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;

namespace Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas
{
    public class HabilitacionUrbanaFichaDto
    {
        public int IdHabilitacionUrbana { get; set; }
        public string? CodigoHabilitacioUrbana { get; set; }
        public string? Nombre { get; set; }
        public string? CodigoUbigeo { get; set; }
        public string? IdHUCarto { get; set; }
        public TipoHabilitacionUrbanaDto? TipoHabilitacionUrbana { get; set; }
    }
}
