using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ClasificacionesPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.LinderoPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.PrediosCatastralesEn;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UsosPredios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.DescripcionPredios
{
    public class DescripcionPredioDto
    {
        public int IdDescripcionPredio { get; set; }
        public string? Estructuracion { get; set; }
        public string? Zonificacion { get; set; }
        public decimal? AreaTitulo { get; set; }
        public decimal? AreaLibre { get; set; }
        public decimal? AreaVerificada { get; set; }
        public decimal? AreaDeclarada { get; set; }
        public int? IdClasificacionPredio { get; set; }
        public int? IdUsoPredio { get; set; }
        public int? IdPredioCatastralEn { get; set; }
        public int IdFicha { get; set; }
        public string? ClasfDescOtros { get; set; }
        public string? PredioCatOtros { get; set; }
        public string? UsoPredioOtros { get; set; }
        public ClasificacionPredioDto? ClasificacionPredio { get; set; }
        public UsoPredioDto? UsoPredio { get; set; }
        public PredioCatastralEnDto? PredioCatastralEn { get; set; }
        public LinderoPredioDto? LinderoPredio { get; set; }
    }
}
