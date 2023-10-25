using Jca.Sigmuni.Application.Dtos.Admins.Area;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentosFichas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FichaDocumentos
{
    public class FichaDocumentoDto
    {
        public int IdFichaDocumento { get; set; }
        public string? NumeroDocumento { get; set; }

        public DateTime? Fecha { get; set; }
        public decimal? TotalArea { get; set; }

        public AreaDto? Area { get; set; }
        public TipoDocumentoFichaDto? TipoDocumentoPresentado { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
