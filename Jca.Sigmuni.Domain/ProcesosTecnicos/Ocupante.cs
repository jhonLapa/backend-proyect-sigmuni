using Jca.Sigmuni.Domain.General;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Ocupante
    {
        public int Id { get; set; }
        public int IdFicha { get; set; }
        public int? IdCondicionPer { get; set; }

        public virtual Persona Persona { get; set; }
        public virtual CondicionPer CondicionPer { get; set; }
        public virtual Ficha Ficha { get; set; }
    }
}
