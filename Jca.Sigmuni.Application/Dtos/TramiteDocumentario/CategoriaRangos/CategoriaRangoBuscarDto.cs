using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.CategoriaRangos
{
    public class CategoriaRangoBuscarDto
    {
        public int Id { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdRango { get; set; }
        public int? IdProcedimiento { get; set; }
        public bool? Estado { get; set; }
    }
}
