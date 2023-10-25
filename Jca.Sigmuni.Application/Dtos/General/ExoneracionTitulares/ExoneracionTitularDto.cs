using Jca.Sigmuni.Application.Dtos.General.CondicionEspecialTitulares;
using Jca.Sigmuni.Application.Dtos.General.TipoExoneraciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares
{
    public class ExoneracionTitularDto
    {
        public int IdExoneracionTitular { get; set; }

        [MaxLength(20, ErrorMessage = "En el campo Numero Resolucion ingrese como máximo 20 carácteres")]
        public string? NumeroResolucion { get; set; }

        [MaxLength(20, ErrorMessage = "En el campo Numero Boleta Pension ingrese como máximo 20 carácteres")]
        public string? NumeroBoletaPension { get; set; }

        public string? AnioResolucion { get; set; }

        public string? AnioBoletaPension { get; set; }

        public DateTime? FechaInicio { get; set; }

        public DateTime? FechaVencimiento { get; set; }

        public bool Estado { get; set; }

        public int? IdCondicionEspecialTitular { get; set; }

        public int? IdTipoExoneracion { get; set; }

        public CondicionEspecialTitularDto? CondicionEspecialTitular { get; set; }

        public TipoExoneracionDto? TipoExoneracion { get; set; }

        [JsonIgnore]
        public int? IdPersona { get; set; }
    }
}
