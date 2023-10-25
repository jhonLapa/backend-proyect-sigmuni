using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonColoniales
{
    public class NormaIntMonColonialDto
    {
        public int IdNormaIntMonColonial { get; set; }
        public string? NumPlano { get; set; }
        public DateTime? Fecha { get; set; }
        public NormaInteresDto NormaInteres { get; set; }

      
        public int? IdMonumentoColonial { get; set; }
    }
}
