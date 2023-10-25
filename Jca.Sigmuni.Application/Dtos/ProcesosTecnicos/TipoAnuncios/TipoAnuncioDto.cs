﻿namespace Jca.Sigmuni.Application.Dtos.ProcesosTecnicos.TipoAnuncios
{
    public class TipoAnuncioDto
    {
        public int IdTipoAnuncio { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
    }
}
