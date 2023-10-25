using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class SolicitudCuc
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






        public virtual Solicitud? Solicitud { get; set; }
        public virtual UnidadCatastral? UnidadCatastral { get; set; }
        public virtual TipoDigitacion? TipoDigitacion { get; set; }
        public virtual Documento? Documento { get; set; }
        public virtual TipoInspeccion? TipoInspeccion { get; set; }
        public virtual Lote? Lote { get; set; }
        public virtual TipoPartidaRegistral? TipoPartidaRegistral { get; set; }
        public virtual Resultado? Resultados { get; set; }

        //public virtual ICollection<Solicitud> SolicitudC { get; set; }


        public SolicitudCuc()
        {
            FechaRegistro = DateTime.UtcNow;
        }
    }
}
