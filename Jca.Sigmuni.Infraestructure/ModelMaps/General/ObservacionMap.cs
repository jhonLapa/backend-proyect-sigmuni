using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class ObservacionMap : IEntityTypeConfiguration<Observacion>
    {
        public void Configure(EntityTypeBuilder<Observacion> builder)
        {
            builder.ToTable("observacion","loc");
            builder.HasKey(t => t.IdObservacion);
            builder.Property(t => t.IdObservacion).HasColumnName("id_observacion");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
