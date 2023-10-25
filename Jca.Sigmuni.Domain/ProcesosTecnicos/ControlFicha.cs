using Jca.Sigmuni.Domain.Base;
using System.Runtime.CompilerServices;
using Jca.Sigmuni.Domain.Incidencias;

namespace Jca.Sigmuni.Domain.ProcesosTecnicos
{
    public class ControlFicha 
    {
        public int Id { get; set; }
        public string? Observacion { get; set; }
        public string? NombreFicha { get; set; }
        public string? NombreTab { get; set; }
        public string? NombreCampo { get; set; }
        public string? ValorAnterior { get; set; }
        public string? ValorActual { get; set; }
        public bool? EsConforme { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public DateTime FechaActualizacion { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        //public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
       
        public int IdFicha { get; set; }
        public int IdUnidadCatastral { get; set; }
        public int IdUsuario { get; set; }


    }
}
