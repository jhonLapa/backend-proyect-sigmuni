using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class LoteBusqueda
    {
        public string? CodigoUbigeo { get; set; }
        public string? CodigoSector { get; set; }
        public string? CodigoManzana { get; set; }
        public string? CodigoLote { get; set; }
        public bool? Estado { get; set; } = true;
    }
}
