using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.Lotes
{
    public class LoteDetalleDto
    {
        public string Ubigeo { get; set; }
        public string Sector { get; set; }
        public string Manzana { get; set; }
        public string Lote { get; set; }
        public string PartidaRegistral { get; set; }
        public string CodigoUnicoCatastral { get; set; }
        public long? TotalUnidadCatastral { get; set; }
        public string CodigoZonificacion { get; set; }
        public string Zonificacion { get; set; }
        public string MzUrbana { get; set; }
        public string LoteUrbano { get; set; }
        public string CodigoHabilitacionUrbana { get; set; }
        public string HabilitacionUrbana { get; set; }
        public string FrenteCampo { get; set; }
        public string DerechaCampo { get; set; }
        public string IzquierdaCampo { get; set; }
        public string FondoCampo { get; set; }
        public string AreaLibre { get; set; }
        public string LoteAntirreglamentario { get; set; }
        public string AreaVerificada { get; set; }
        public string EstadoConservacion { get; set; }
        public long? TotalAreaTechada { get; set; }
        public string Arancel { get; set; }
        public string UsoPredominante { get; set; }
        public List<LoteDetalleViaDto> LoteDetalleVia { get; set; }
        public List<ConstruccionDto> Construccion { get; set; }
    }
}
