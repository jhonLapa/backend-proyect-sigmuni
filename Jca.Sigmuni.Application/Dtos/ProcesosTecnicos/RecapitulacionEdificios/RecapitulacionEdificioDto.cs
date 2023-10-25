using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionEdificios
{
    public class RecapitulacionEdificioDto
    {
        public int? Id { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Edificio ingrese como máximo 100 carácteres")]
        public string? Edificio { get; set; }
        public decimal? TotalPorcentaje { get; set; }
        public decimal? TotalAtc { get; set; }
        public decimal? TotalAcc { get; set; }
        public decimal? TotalAoic { get; set; }

        [JsonIgnore]
        //[Required(ErrorMessage = "Id Ficha es requerido entidad Ubicacion Predio")]
        public int IdFicha { get; set; }
    }
}
