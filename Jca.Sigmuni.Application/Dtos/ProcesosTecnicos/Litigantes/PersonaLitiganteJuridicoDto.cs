using Jca.Sigmuni.Application.Dtos.General.CategoriaOrganizaciones;
using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.General.TipoPersonas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Litigantes
{
    public class PersonaLitiganteJuridicoDto
    {
        public int Id { get; set; }

        public int IdPersona { get; set; }

        public TipoPersonaDto TipoPersona { get; set; }

        public DocumentoIdentidadDto DocumentoIdentidad { get; set; }

        //[MaxLength(11, ErrorMessage = "En el campo Ruc ingrese como máximo 11 carácteres")]
        public string NumeroRuc { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo RazonSocial ingrese como máximo 100 carácteres")]
        public string RazonSocial { get; set; }

        public CategoriaOrganizacionDto CategoriaOrganizacion { get; set; }

        //[MaxLength(10, ErrorMessage = "En el campo CodigoContribuyenteSat ingrese como máximo 10 carácteres")]
        public string CodigoContribuyenteSat { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
