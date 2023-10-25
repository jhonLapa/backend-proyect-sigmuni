using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class Categoria
    {
        public int IdCategoria { get; set; }        
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public virtual ICollection<CategoriaRango> CategoriaRango { get; set; }
    }
}
