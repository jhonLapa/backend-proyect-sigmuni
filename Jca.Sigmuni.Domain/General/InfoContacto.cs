using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class InfoContacto
    {
        public int Id { get; set; }
        public string? Telefono { get; set; }
        public string? Correo { get; set; }
        public string? Anexo { get; set; }
        public string? Fax { get; set; }
        public int? IdPersona { get; set; }
        public int? IdTipoPersona { get; set; }
        public int? IdUsuarioAccion { get; set; } 
        public string? Ip { get; set; }

        public virtual Persona? Persona { get; set; }
        public virtual TipoPersona? TipoPersona { get; set; }
    }
}
