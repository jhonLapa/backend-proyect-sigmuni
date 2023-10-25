using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesTitulares;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.ExoneracionPredios;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.FormaAdquisiciones;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CaracteristicaTitularidades
{
    public class CaracteristicaTitularidadDto
    {
        public int IdCaracteristicaTitularidad { get; set; }
        public int? IdCondicionTitular { get; set; }
        public int? IdFormaAdquisicion { get; set; }
        public int? IdExoneracionPredio { get; set; }
        public string? CondicionTitularOtros { get; set; }
        public string? FormaAdquisicionOtros { get; set; }
        public string? PorcentajeTitularidad { get; set; }
        public DateTime? FechaAdquisicion { get; set; }

        public virtual CondicionTitularDto? CondicionTitular { get; set; }
        public virtual FormaAdquisicionDto? FormaAdquisicion { get; set; }
        public virtual ExoneracionPredioDto? ExoneracionPredio { get; set; }
    }
}
