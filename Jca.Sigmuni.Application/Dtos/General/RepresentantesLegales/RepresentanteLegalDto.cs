using Jca.Sigmuni.Application.Dtos.Admins.Domicilios;
using Jca.Sigmuni.Application.Dtos.General.InfoContactos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jca.Sigmuni.Application.Dtos.General.RepresentantesLegales
{
    public class RepresentanteLegalDto
    {
        public int? Id { get; set; }
        public string? Codigo { get; set; }
        public string? Nombre { get; set; }
        public string? Paterno { get; set; }
        public string? Materno { get; set; }
        public string? Correo { get; set; }
        public string? NumeroDni { get; set; }
        public string? NumeroRuc { get; set; }
        public string? Documento { get; set; }
        public string? Direccion { get; set; }
        public string? CodigoContribuyente { get; set; }
        public string? Asociacion { get; set; }
        public string? RazonSocial { get; set; }
        public DateTime? FechaRegistro { get; set; }
        public bool? Estado { get; set; }
        public string? EstadoNombre { get; set; }
        public List<DomicilioDto>? Domicilio { get; set; }
        public List<InfoContactoDto>? InfoContacto { get; set; }
    }
}
