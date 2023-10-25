using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.TramiteDocumentario
{
    public class AdministracionCarto
    {
        public string Id { get; set; }
        public string CodigoUbigeo { get; set; }
        public string NumeroSolicitud { get; set; }
        public string Anio { get; set; }
        public string TipoTramite { get; set; }
        public string AsuntoTramite { get; set; }
        public string FechaInicio { get; set; }
        public string CodSector { get; set; }
        public string CodManzana { get; set; }
        public string CodLote { get; set; }
        public string CodEdif { get; set; }
        public string CodEnt { get; set; }
        public string CodPiso { get; set; }
        public string CodUnid { get; set; }
        public string Nombres { get; set; }
        public string ApPaterno { get; set; }
        public string ApMaterno { get; set; }
        public string Estado { get; set; }
        public int Flag { get; set; }
        public string IdDocumento { get; set; }
    }
}
