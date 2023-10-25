using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TitularCatastrales;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CotitularesCatastrales
{
    public class CotitularCatastralDto
    {
        public CaracteristicaTitularidadDto? CaracteristicaTitularidad { get; set; }

        public PersonaTitularDto? Titular { get; set; }

        public DomicilioTitularCatastralDto? DomicilioTitular { get; set; }
    }
}
