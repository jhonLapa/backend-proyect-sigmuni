using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.UnidadesCatastrales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInspecciones;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoPartidaRegistrales;
using Jca.Sigmuni.Application.Dtos.TramiteDocumentario.TipoDigitacions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.TramiteDocumentario.SolicitudCucs
{
    public class SolicitudCucDto
    {
        public int Id { get; set; }
        public int IdSolicitud { get; set; }
        public int? IdUnidadCatastral { get; set; }
        public int? IdTipoDigitacion { get; set; }
        public int? IdDocumento { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? DireccionReferencial { get; set; }
        public string? Modificacion { get; set; }
        public int? IdResultado { get; set; }
        public int? AreaConstruida { get; set; }
        public float? AreaTerreno { get; set; }
        public int? IdTipoInspeccion { get; set; }
        public bool? Estado { get; set; } = true;
        public DateTime FechaRegistro { get; set; }
        public int? IdTipoPartidaRegistral { get; set; }
        public string? Numero { get; set; }
        public string? Fojas { get; set; }
        public string? Asiento { get; set; }

        public string? CodigoDistrito { get; set; }
        public string? NombreHu { get; set; }
        public string? Mz { get; set; }
        public string? LoteDireccion { get; set; }
        public string? NombreVia { get; set; }
        public string? Nro { get; set; }
        public string? Interior { get; set; }
        public int? AnioUnidadCatastral { get; set; }
        public UnidadCatastralDto? UnidadCatastral { get; set; }
        public LoteDto? Lote { get; set; }
        public TipoInspeccionDto? TipoInspeccion { get; set; }
        public TipoDigitacionDto? TipoDigitacion { get; set; }
        public TipoPartidaRegistralDto? TipoPartidaRegistral { get; set; }

        //public List<RevisionCucSolicitudDto> RevisionCucSolicitud { get; set; }
    }
}
