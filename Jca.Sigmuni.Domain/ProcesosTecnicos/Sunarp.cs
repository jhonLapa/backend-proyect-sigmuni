using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class Sunarp
    {
        public int Id { get; set; }
        public string? NumeroPartida { get; set; }
        public string? Fojas { get; set; }
        public string? Asiento { get; set; }
        public string? DeclaratoriaFabrica { get; set; }
        public DateTime? FechaInscripcion { get; set; }
        public string? AsientoFabrica { get; set; }
        public DateTime? FechaFabrica { get; set; }
        public int? IdTipoPartidaRegistral { get; set; }
        public int IdFicha { get; set; }
        public int? IdTipoTituloInscrito { get; set; }
        public int? IdMonumentoPre { get; set; }
        public int? IdMonumentoColonial { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool? Estado { get; set; } = true;

        public virtual TipoPartidaRegistral TipoPartidaRegistral { get; set; }
        public virtual TipoTituloInscrito TipoTituloInscrito { get; set; }
        public virtual Ficha Ficha { get; set; }
        public virtual MonumentoPrehispanico MonumentoPreinspanico { get; set; }
        public virtual MonumentoColonial MonumentoColonial { get; set; }
    }
}
