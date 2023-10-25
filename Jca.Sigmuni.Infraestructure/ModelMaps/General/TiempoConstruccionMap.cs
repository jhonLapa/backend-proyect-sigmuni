using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class TiempoConstruccionMap : IEntityTypeConfiguration<TiempoConstruccion>
    {
        public void Configure(EntityTypeBuilder<TiempoConstruccion> builder)
        {
            builder.ToTable("tiempo_construccion","loc");
            builder.HasKey(t => t.IdTiempoConstruccion);
            builder.Property(t => t.IdTiempoConstruccion).HasColumnName("id_tiempo_construccion");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(60);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(500);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
