using Jca.Sigmuni.Application.Dtos.General.TblCodigos;

namespace Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales
{
    public class UnidadCatastralDto
    {
        public int IdUnidadCatastral { get; set; }
        public string? CodigoCatastral { get; set; }
        public string? CodigoHojaCatastral { get; set; }
        public string? CodigoPredialSat { get; set; }
        public string? UnidadAcumuladaCodigo { get; set; }
        public string? Correlativo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public int IdMotivo { get; set; }
        public string? CodigoRefCatastral { get; set; }
        public string? Ambito { get; set; }
        public string? IdLoteCarto { get; set; }
        public int? AnioUltimoDDJJ { get; set; }
        public string? Cuc { get; set; }
        //public MotivoDto Motivo { get; set; }

        //public ImagenPredioPrincipalDto ImagenPrincipalPredio { get; set; }
        public List<TblCodigoCatastralDto>? TblCodigo { get; set; }

        
    }
}
