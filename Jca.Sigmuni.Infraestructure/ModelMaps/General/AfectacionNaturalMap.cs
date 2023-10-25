using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class AfectacionNaturalMap : IEntityTypeConfiguration<AfectacionNatural>
    {
        public void Configure(EntityTypeBuilder<AfectacionNatural> builder)
        {
            builder.ToTable("afectacion_natural", "loc");
            builder.HasKey(t => t.IdAfectacionNatural);
            builder.Property(t => t.IdAfectacionNatural).HasColumnName("id_afectacion_natural");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
