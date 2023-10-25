using Jca.Sigmuni.Domain.General;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jca.Sigmuni.Infraestructure.ModelMaps.General
{
    public class AfectacionAntropicaMap : IEntityTypeConfiguration<AfectacionAntropica>
    {
        public void Configure(EntityTypeBuilder<AfectacionAntropica> builder)
        {
            builder.ToTable("afectacion_antropica", "loc");
            builder.HasKey(t => t.IdAfectacionAntropica);
            builder.Property(t => t.IdAfectacionAntropica).HasColumnName("id_afectacion_antropica");
            builder.Property(e => e.Codigo).HasColumnName("codigo").IsUnicode(false).HasMaxLength(10);
            builder.Property(e => e.Descripcion).HasColumnName("descripcion").IsUnicode(false).HasMaxLength(300);
            builder.Property(e => e.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(e => e.Estado).HasColumnName("estado");

        }
    }
}
