using Jca.Sigmuni.Application.Dtos.General.TblCodigos;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.OtraInstalaciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.UbicacionPredios;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Valorizaciones
{
    public class ValorizacionDetalleDto
    {
        public int? AnioFicha { get; set; }
        public TblCodigoCatastralDto CodigoCatastral { get; set; }
        //public SupervisorPersonaDto SupervisorInfo { get; set; }
        //public TecnicoCatastralPersonaDto TecnicoInfo { get; set; }
        public List<ValorConstruccionDto> ValorConstruccion { get; set; }
        public List<OtraInstalacionDto> OtraInstalaciones { get; set; }
        public PersonaTitularDto Titular { get; set; }
        public UbicacionPredioDto Ubicacion { get; set; }
        public decimal? ValorTotalConstruccion { get; set; }
        public decimal? ValorTotalObrasComplementarias { get; set; }

        // Ubicación del predio
        public ViaDto Via { get; set; }
        public string NumeroInterior { get; set; }
        public string NumLote { get; set; }
        public string Manzana { get; set; }
        public string NumeroMunicipal { get; set; }

        // Datos parciales de valores totales
        public decimal? ValorTerreno { get; set; }

        // Datos del contribuyente
        public decimal? AreaTerreno { get; set; }
        public decimal? ValorArancelario { get; set; }
    }
}
