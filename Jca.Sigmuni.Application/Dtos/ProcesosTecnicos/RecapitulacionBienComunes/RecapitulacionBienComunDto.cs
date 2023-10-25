using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.RecapitulacionBienComunes
{
    public class RecapitulacionBienComunDto
    {
        public int? Id { get; set; }
        public string? Numero { get; set; }
        public string? Edificacion { get; set; }
        public string? Entrada { get; set; }
        public string? Piso { get; set; }
        public string? Unidad { get; set; }
        public decimal? Porcentaje { get; set; }
        public decimal? LegalTerreno { get; set; }
        public decimal? LegalConstruccion { get; set; }
        public decimal? FisicoTerreno { get; set; }
        public decimal? FisicoConstruccion { get; set; }
        public decimal? Atc { get; set; }
        public decimal? Acc { get; set; }
        public decimal? Aoic { get; set; }

        [JsonIgnore]
        //[Required(ErrorMessage = "Id Ficha es requerido entidad Ubicacion Predio")]
        public int IdFicha { get; set; }
    }
}
