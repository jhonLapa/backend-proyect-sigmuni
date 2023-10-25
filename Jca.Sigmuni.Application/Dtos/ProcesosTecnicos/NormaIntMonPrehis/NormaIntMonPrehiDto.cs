using Jca.Sigmuni.Application.Dtos.CompendioNormas.NormasInteres;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.NormaIntMonPreins
{
    public class NormaIntMonPrehiDto
    {
        public int IdNormaIntMonPrehi { get; set; }
        public string? NumPlano { get; set; }
        public DateTime? Fecha { get; set; }
        public NormaInteresDto NormaInteres { get; set; }

        
        public int? IdMonumentoPre { get; set; }


    }
}
