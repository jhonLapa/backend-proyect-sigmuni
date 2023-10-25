using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales
{
    public class UnidadCatastralFormDto
    {
        public int IdUnidadCatastral { get; set; }
        public string? CodigoCatastral { get; set; }
        public string? CodigoHojaCatastral { get; set; }
        public string? UnidadAcumuladaCodigo { get; set; }
        public string? CodigoPredialSat { get; set; }
        public string? Correlativo { get; set; }
        public int? IdMotivo { get; set; }
        public string? CodigoRefCatastral { get; set; }
        public string? Ambito { get; set; }
        public string? IdLoteCarto { get; set; }
        public int? AnioUltimoDDJJ { get; set; }
        public string? Cuc { get; set; }
    }
}
