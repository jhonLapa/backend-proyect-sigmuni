using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class IntervencionConservacionMap : IEntityTypeConfiguration<IntervencionConservacion>
    {
        public void Configure(EntityTypeBuilder<IntervencionConservacion> builder)
        {
            builder.ToTable("intervencion_conservacion","loc");
            builder.HasKey(t => t.IdIntervencionConservacion);
            builder.Property(t => t.IdIntervencionConservacion).HasColumnName("id_intervencion_conservacion");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
