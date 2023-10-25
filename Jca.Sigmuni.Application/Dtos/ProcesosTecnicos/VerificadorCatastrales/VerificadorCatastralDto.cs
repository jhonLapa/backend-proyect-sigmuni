using Jca.Sigmuni.Application.Dtos.General.DocumentoIdentidades;
using Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.CondicionesPer;
using Jca.Sigmuni.Domain.General;
using Jca.Sigmuni.Domain.ProcesosTecnicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.VerificadorCatastrales
{
    public class VerificadorCatastralDto
    {
        public int? Id { get; set; }
        public int? IdPersona { get; set; }
        public int? IdCondicionPer { get; set; }
        public int? IdFicha { get; set; }
        public string? NumeroRegistro { get; set; }
        public bool? TieneFirma { get; set; }
        public DateTime? Fecha { get; set; }
        public DocumentoIdentidadDto? DocumentoIdentidad { get; set; }
        public string? NumeroDni { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public virtual CondicionPerDto? CondicionPer { get; set; }
    }
}
