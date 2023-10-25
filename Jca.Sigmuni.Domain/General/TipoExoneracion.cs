﻿namespace Jca.Sigmuni.Domain.General
{
    public class TipoExoneracion
    {
        public int IdTipoExoneracion { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;

        public virtual ICollection<ExoneracionTitular> ExoneracionTitulares { get; set; }
    }
}
