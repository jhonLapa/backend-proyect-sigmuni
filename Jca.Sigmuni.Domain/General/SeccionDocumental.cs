﻿using Jca.Sigmuni.Domain.ArchivoDocumentario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Domain.General
{
    public class SeccionDocumental
    {
        public int Id { get; set; }
        public string? Codigo { get; set; }
        public string? Descripcion { get; set; }
        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
        public bool? Estado { get; set; } = true;
        public string? EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
        public string? Siglas { get; set; }
        public virtual ICollection<InfDocumento> InfDocumento { get; set; }
    }
}
