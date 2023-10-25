using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.InfoContactos
{
    public class InfoContactoPersonaDto
    {
        public string? Correo { get; set; }
        public string? Telefono { get; set; }
        public string? Anexo { get; set; }
        public string? Fax { get; set; }

        [JsonIgnore]
        public int IdPersona { get; set; }

        [JsonIgnore]
        public int IdTipoPersona { get; set; }
    }
}
