using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using System.Text.Json.Serialization;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Declarantes
{
    public class DeclarantePersonaDto
    {
        public int? IdDeclarante { get; set; }

        public int? IdPersona { get; set; }
        public int? IdCondicionPer { get; set; }

        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }

        //[MaxLength(30, ErrorMessage = "En el campo NumeroDni ingrese como máximo 30 carácteres")]
        public string? NumeroDni { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Nombre ingrese como máximo 100 carácteres")]
        public string? Nombre { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Paterno ingrese como máximo 100 carácteres")]
        public string? Paterno { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo Materno ingrese como máximo 60 carácteres")]
        public string? Materno { get; set; }

        public DateTime? Fecha { get; set; }

        public bool? TieneFirma { get; set; }

        public CondicionPerDto? CondicionPer { get; set; }

        
        public int? IdFicha { get; set; }
    }
}
