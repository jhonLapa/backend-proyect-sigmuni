﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class Sector
    {
        public string Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public int? AreaGrafica { get; set; }
        public string? CodigoUbigeo { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public virtual ICollection<Manzana> Manzana { get; set; }
        public Ubigeo Ubigeo { get; set; }
    }
}
