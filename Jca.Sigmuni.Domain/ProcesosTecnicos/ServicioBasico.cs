using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ServicioBasico
    {
        public int IdServicioBasico { get; set; }
        public int? IdLuz { get; set; }
        public int? IdAgua { get; set; }
        public int? IdTelefono { get; set; }
        public int? IdDesague { get; set; }
        public int? IdGas { get; set; }
        public int? IdInternet { get; set; }
        public int? IdCable { get; set; }
        public string? SuministroLuz { get; set; }
        public string? NumContratoAgua { get; set; }
        public string? NumTelefono { get; set; }
        public string? SuministroGas { get; set; }
        public string? Anexo { get; set; }
        public int IdFicha { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Ficha Ficha { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoLuz { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoAgua { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoTelefono { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoDesague { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoGas { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoInternet { get; set; }
        public virtual TipoServicioBasico TipoServicioBasicoCable { get; set; }
    }
}
