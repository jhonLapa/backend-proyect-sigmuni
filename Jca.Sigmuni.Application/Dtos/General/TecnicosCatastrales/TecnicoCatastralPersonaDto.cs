using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.TecnicosCatastrales
{
    public class TecnicoCatastralPersonaDto
    {
        public int IdTecnico { get; set; }

        public int IdPersona { get; set; }


        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }

        //[MaxLength(30, ErrorMessage = "En el campo NumeroDni ingrese como máximo 30 carácteres")]
        public string? NumeroDni { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Nombre ingrese como máximo 100 carácteres")]
        public string? Nombre { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Paterno ingrese como máximo 100 carácteres")]
        public string? Paterno { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo Materno ingrese como máximo 60 carácteres")]
        public string Materno { get; set; }

        public DateTime? Fecha { get; set; }

        public bool? TieneFirma { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
