using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoResoluciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Resoluciones
{
    public class ResolucionDto
    {
        public string IdResolucion { get; set; }
        public string NumeroResolucion { get; set; }
        public string Anio { get; set; }
        public string NumeroPlano { get; set; }

        public virtual TipoResolucionDto TipoResolucion { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
