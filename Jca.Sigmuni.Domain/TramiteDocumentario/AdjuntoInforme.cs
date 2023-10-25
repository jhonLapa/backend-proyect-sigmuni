using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class AdjuntoInforme
    {
        public int Id { get; set; }
        public int IdInformeTecnico { get; set; }
        public int IdDocumento { get; set; }
        public int Flag { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }

        public virtual InformeTecnico InformeTecnico { get; set; }
        public virtual Documento Documento { get; set; }

        public AdjuntoInforme()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = true;
        }
    }
}
