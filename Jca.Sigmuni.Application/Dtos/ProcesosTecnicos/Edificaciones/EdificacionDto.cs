using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAgrupaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoEdificaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Edificaciones
{
    public class EdificacionDto
    {
        public int IdEdificacion { get; set; }

        //[MaxLength(100, ErrorMessage = "En el campo Nombre ingrese como máximo 100 carácteres")]
        public string? Nombre { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo Manzana ingrese como máximo 60 carácteres")]
        public string? Manzana { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo Lote ingrese como máximo 60 carácteres")]
        public string? NumLote { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo LoteUrbano ingrese como máximo 60 carácteres")]
        public string? LoteUrbano { get; set; }

        //[MaxLength(60, ErrorMessage = "En el campo SubLote ingrese como máximo 60 carácteres")]
        public string? SubLote { get; set; }


        public TipoEdificacionDto? TipoEdificacion { get; set; }

        public TipoAgrupacionDto? TipoAgrupacion { get; set; }
        public bool? Estado { get; set; }
    }
}
