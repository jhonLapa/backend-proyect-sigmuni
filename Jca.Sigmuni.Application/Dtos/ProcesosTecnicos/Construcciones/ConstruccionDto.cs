using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Eccs;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ecss;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.EdificacionesIndustriales;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Meps;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Ucas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.Construcciones
{
    public class ConstruccionDto
    {
        public int Id { get; set; }
        public string? NumeroPiso { get; set; }
        public string? EstructuraMuroColumna { get; set; }
        public string? EstructuraTecho { get; set; }

        public string? AcabadoPiso { get; set; }
        public string? AcabadoPuertaVentana { get; set; }

        public string? AcabadoRevestimiento { get; set; }

        public string? AcabadoBanio { get; set; }

        public string? InstalacionElectricaSanitaria { get; set; }

        public decimal? AreaVerificada { get; set; }

        public decimal? AreaTechadaDeclarada { get; set; }

        public string? IdEd { get; set; }
        public DateTime? MesAnio { get; set; }
        public virtual MepDto? Mep { get; set; }
        public virtual EcsDto? Ecs { get; set; }
        public virtual EccDto? Ecc { get; set; }
        public virtual UcaDto? Uca { get; set; }
        public EdificacionIndustrialDto? EdificacionIndustrial { get; set; }

        [JsonIgnore]
        public int IdFicha { get; set; }
    }
}
