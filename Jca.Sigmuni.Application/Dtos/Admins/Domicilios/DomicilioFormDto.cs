using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.Admins.Domicilios
{
    public  class DomicilioFormDto
    {
        public string? NumMunicipal { get; set; }
        public string? LtPrincipal { get; set; }
        public string? LtSecundario { get; set; }
        public int? IdTipoInterior { get; set; }
        public string? NumInterior { get; set; }
        public string? LtInterior { get; set; }
        public int? IdEdificacion { get; set; }
        public string? CasillaPostal { get; set; }
        public int? IdTipoVia { get; set; }
        public string? IdVia { get; set; }
        public string? NombreVia { get; set; }
        public string? CodigoUbigeo { get; set; }
        public int? IdTipoHU { get; set; }
        public int? IdHU { get; set; }
        public string? NombreHU { get; set; }
        public int? IdPersona { get; set; }
        public int? IdDenominacionInterior { get; set; }
        public string? IdLoteCarto { get; set; }
        public string? Manzana { get; set; }
        public int? IdPuerta { get; set; }
    }
}
