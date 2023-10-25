using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ActividadesVerificadas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.GirosAutorizados;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.AutorizacionesMunicipales
{
    public class AutorizacionMunicipalDto
    {
        public int IdAutorizacionMunicipal { get; set; }

        public int IdFicha { get; set; }
        public GiroAutorizadoDto? GiroAutorizado { get; set; }
        public ActividadVerificadaDto? ActividadVerificada { get; set; }

        
        
    }
}
