using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.InfoContactos
{
    public class InfoContactoFormDto
    {
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Anexo { get; set; }
        public string? Fax { get; set; }
        public int? IdPersona { get; set; }
        public int? IdTipoPersona { get; set; }
        public string? Ip { get; set; }
    }
}
