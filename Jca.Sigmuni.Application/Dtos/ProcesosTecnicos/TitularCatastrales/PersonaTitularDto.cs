using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.Dependientes;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.EstadoCivil;
using Jca.Sigmuni.Application.Dtos.General.ExoneracionTitulares;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales
{
    public class PersonaTitularDto
    {
        public int IdPersona { get; set; }

        public int IdTitularCatastral { get; set; }

        public int? NumTitularidad { get; set; }

        public TipoPersonaDto? TipoPersona { get; set; }

        public EstadoCivilDto? EstadoCivil { get; set; }

        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }

        //[MaxLength(30, ErrorMessage = "En el campo NumeroDni ingrese como máximo 30 carácteres")]
        public string? NumeroDni { get; set; }

        //[MaxLength(30, ErrorMessage = "En el campo Documento ingrese como máximo 30 carácteres")]
        public string? CodigoContribuyente { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Nombre ingrese como máximo 100 carácteres")]
        public string? Nombre { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Paterno ingrese como máximo 100 carácteres")]
        public string? Paterno { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo Materno ingrese como máximo 60 carácteres")]
        public string? Materno { get; set; }

        //[MaxLength(11, ErrorMessage = "En el campo Ruc ingrese como máximo 11 carácteres")]
        public string? NumeroRuc { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo RazonSocial ingrese como máximo 100 carácteres")]
        public string? RazonSocial { get; set; }

        public CategoriaOrganizacionDto? CategoriaOrganizacion { get; set; }

        public InfoContactoPersonaDto? Contacto { get; set; }

        [JsonIgnore]
        public int? IdCaracteristicaTitularidad { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }

        public ConyugeTitularDto? Conyuge { get; set; }
        public ExoneracionTitularDto? ExoneracionTitular { get; set; }
    }
}
