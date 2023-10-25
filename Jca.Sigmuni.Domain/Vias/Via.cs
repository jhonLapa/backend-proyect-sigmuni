using Jca.Sigmuni.Domain.Admins;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.Vias
{
    public class Via
    {
        public string IdVia { get; set; }
        public string? CodVia { get; set; }
        public string? Nombre { get; set; }
        public string? NomenclaturaHistoricoI { get; set; }
        public string? NomenclaturaHistoricoII { get; set; }
        public string? NumeroCuadra { get; set; }
        public string? Frente { get; set; }
        public string? Nota { get; set; }
        public string? Observacion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? CodigoUbigeo { get; set; }
        public int? IdLado { get; set; }
        public int? IdTipoVia { get; set; }
        public int? IdUsuario { get; set; }


        //public virtual Ubigeo Ubigeo { get; set; }
        //public virtual Lado Lado { get; set; }
        public virtual TipoVia TipoVia { get; set; }

        // public virtual ICollection<ViaTramo> ViaTramo { get; set; }
        // public virtual ICollection<ViaNormaInteres> ViaNormaInteres { get; set; }
        //public virtual ICollection<ViaDocumento> ViaDocumento { get; set; }
        // public virtual ICollection<LoteVia> LoteVia { get; set; }

        //public virtual ICollection<Puerta> Puertas { get; set; }
        public virtual ICollection<Domicilio> Domicilio { get; set; }
        public virtual ICollection<Arancel> Arancel { get; set; }
        public virtual ICollection<Puerta> Puertas { get; set; }
        //public virtual ICollection<Domicilio> Domicilio { get; set; }
        // public virtual ICollection<ImagenVia> ImagenVia { get; set; }
    }
}
