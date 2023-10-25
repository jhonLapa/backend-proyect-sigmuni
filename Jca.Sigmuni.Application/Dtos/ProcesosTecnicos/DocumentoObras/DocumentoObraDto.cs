using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoDocumentoObras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DocumentoObras
{
    public class DocumentoObraDto
    {
        public string Id { get; set; }
        public string NumeroDocumento { get; set; }
        public DateTime? Fecha { get; set; }
        public string Piso { get; set; }
        public decimal? AreaAutorizada { get; set; }

        public virtual TipoDocumentoObraDto TipoDocumentoObra { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
