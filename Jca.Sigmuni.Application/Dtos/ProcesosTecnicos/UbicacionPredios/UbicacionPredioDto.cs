using Jca.Sigmuni.Application.Dtos.Habilitaciones.HabilitacionUrbanaFichas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios
{
    public class UbicacionPredioDto
    {
        public int Id { get; set; }

        //[MaxLength(500, ErrorMessage = "En el campo DenominacionPredio ingrese como máximo 100 carácteres")]
        public string? DenominacionPredio { get; set; }

        public HabilitacionUrbanaFichaDto? HabilitacionUrbana { get; set; }


        [JsonIgnore]
        //[Required(ErrorMessage = "Id Ficha es requerido entidad Ubicacion Predio")]
        public int IdFicha { get; set; }

        [JsonIgnore]
        //[Required(ErrorMessage = "IdEdificacion es requerido entidad Ubicacion Predio")]
        public int IdEdificacion { get; set; }
    }
}
