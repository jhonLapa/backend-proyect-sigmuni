using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones
{
    public class ValorConstruccionDto
    {
        public string Nivel { get; set; }
        public string TipoNivel { get; set; }
        public string AnioConstruccion { get; set; }
        public string Clasificacion { get; set; }
        public string MaterialPredominante { get; set; }
        public string EstadoConservacion { get; set; }
        public string MuroColumnna { get; set; }
        public string MuroColumnnaValor { get; set; }
        public string Techo { get; set; }
        public string TechoValor { get; set; }
        public string Piso { get; set; }
        public string PisoValor { get; set; }
        public string Puerta { get; set; }
        public string PuertaValor { get; set; }
        public string Revestimiento { get; set; }
        public string RevestimientoValor { get; set; }
        public string Banio { get; set; }
        public string BanioValor { get; set; }
        public string InstaElectrica { get; set; }
        public string InstaElectricaValor { get; set; }
        public string ValorUnitarioM2 { get; set; }
        public string Incremento { get; set; }
        public string PorcentajeDepreciacion { get; set; }
        public string ValorDepreciacion { get; set; }
        public string AreaConstruida { get; set; }
        public string EstructuraMuroColumna { get; set; }
        public string EstructuraTecho { get; set; }
        public string AcabadoPiso { get; set; }
        public string AcabadoPuertaVentana { get; set; }
        public string AcabadoRevestimiento { get; set; }
        public string AcabadoBanio { get; set; }
        public string InstalacionElectricaSanitaria { get; set; }
        public decimal? ValorUnitario { get; set; }
        public decimal? PorcentajeValorDepreciado { get; set; }
        public decimal? ValorDepreciado { get; set; }
        public decimal? PorcentajeAreaComun { get; set; }
        public decimal? ValorAreaComun { get; set; }
        public decimal? ValorConstruccion { get; set; }
        public decimal? AreaVerificada { get; set; }
    }
}
