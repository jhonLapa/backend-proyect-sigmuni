using Jca.Sigmuni.Application.Dtos.General.Edificaciones.Edificaciones;
using Jca.Sigmuni.Application.Dtos.General.Lotes;
using Jca.Sigmuni.Application.Dtos.General.Ubigeos;
using Jca.Sigmuni.Application.Dtos.Habilitaciones.TipoHabilitacionesUrbanas;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoInteriores;
using Jca.Sigmuni.Application.Dtos.Vias.TipoVias;
using Jca.Sigmuni.Application.Dtos.Vias.Vias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios
{
    public class DomicilioPersonaDto
    {
        public int Id { get; set; }
        public string NumMunicipal { get; set; }
        public string LtPrincipal { get; set; }
        public int IdTipoInterior { get; set; }
        public string NumeroInterior { get; set; }
        public int IdEdificacion { get; set; }
        public int IdPersona { get; set; }
        public bool Estado { get; set; }
        public string CasillaPostal { get; set; }
        public string IdVia { get; set; }
        public string CodigoUbigeo { get; set; }
        public string LtSecundario { get; set; }
        public string IdHabilitacionUrbana { get; set; }

    
        public UbigeoDto Ubigeo { get; set; }
        public TipoInteriorDto TipoInterior { get; set; }
        public EdificacionDto Edificacion { get; set; }
        public ViaDto Via { get; set; }


        //public DenominacionInteriorDto DenominacionInterior { get; set; }
        public TipoViaDto TipoVia { get; set; }
        public TipoHabilitacionUrbanaDto TipoHabilitacionesUrbanas { get; set; }
        public LoteDto Lote { get; set; }
        public string NombreVia { get; set; }
        public string NombreHabilitacionUrbana { get; set; }
        public string LtInterior { get; set; }
        public string Manzana { get; set; }
    }
}
