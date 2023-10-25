using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones
{
    public class ValorizacionBusquedaDto
    {
        public int? IdFicha { get; set; }
        public int? IdFichaPadre { get; set; }
        public string? IdUnidadCatastral { get; set; }
        public string? IdFichaControl { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? Anio { get; set; }
        public string? CodigoUbigeo { get; set; }
        public string? CodigoSector { get; set; }
        public string? CodigoManzana { get; set; }
        public string? CodigoLote { get; set; }
        public string? CodigoEdif { get; set; }
        public string? CodigoEnt { get; set; }
        public string? CodigoPiso { get; set; }
        public string? CodigoUnid { get; set; }
        public string? DigitoControl { get; set; }
        public string? TipoPersona { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Titular { get; set; }
        public decimal? ValorTerreno { get; set; }
        public decimal? ValorizacionTotal { get; set; }
        public decimal? ValorTotalConstruccion { get; set; }
        public decimal? ValorTotalObrasComplementarias { get; set; }
    }
}
