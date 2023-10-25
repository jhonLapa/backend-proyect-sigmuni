using System;
namespace Jca.Sigmuni.Domain.Base
{
	public abstract class ModelBase<K>
	{
		public K Id { get; set; }
		public virtual string Nombre { get; set; }
		public string? Descripcion { get; set; }
		public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;
		public bool? Estado { get; set; } = true;
		public string EstadoNombre { get => (Estado != null && Estado == true) ? "Activo" : "Inactivo"; }
	}
}

