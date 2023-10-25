using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Construccion
    {
        public int IdConstruccion { get; set; }
        public string? NumeroPiso { get; set; }
        public string? EstructuraMuroColumna { get; set; }
        public string? EstructuraTecho { get; set; }
        public string? AcabadoPiso { get; set; }
        public string? AcabadoPuertaVentana { get; set; }
        public string? AcabadoRevestimiento { get; set; }
        public string? AcabadoBanio { get; set; }
        public string? InstalacionElectricaSanitaria { get; set; }
        public decimal? AreaVerificada { get; set; }
        public decimal? AreaTechadaDeclarada { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? PorcentajeValorDepreciado { get; set; }
        public decimal? ValorDepreciado { get; set; }
        public decimal? PorcentajeAreaComun { get; set; }
        public decimal? ValorAreaComun { get; set; }
        public decimal? ValorConstruccion { get; set; }
        public int? IdMep { get; set; }
        public int? IdEcs { get; set; }
        public int? IdEcc { get; set; }
        public int? IdUca { get; set; }
        public int IdFicha { get; set; }
        public string? IdEd { get; set; }
        public int? IdEdificacionIndustrial { get; set; }
        public DateTime? MesAnio { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual Mep Mep { get; set; }
        public virtual Ecs Ecs { get; set; }
        public virtual Ecc Ecc { get; set; }
        public virtual Uca Uca { get; set; }
        public virtual Ficha Ficha { get; set; }
        public virtual EdificacionIndustrial EdificacionIndustrial { get; set; }
    }
}
